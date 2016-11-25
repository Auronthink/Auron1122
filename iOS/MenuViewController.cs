using System;
using System.Collections.Generic;
using UIKit;
using static System.Console;
using System.Threading.Tasks;

namespace Auron.iOS
{
	public partial class MenuViewController : UIViewController
	{
		//public User SelectedUser { set; get; }
		private Food SelectedFood;
		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Task.Run(() =>
			{
				Task.Delay(4000);
				InvokeOnMainThread(() =>
				{
					ShowTable();
				});
			});
		}

		// 要改成asyncwait
		private void ShowTable()
		{
			//var list = new List<User>
			//{
			//	new User {Name = @"Aa", Description = @"使用者 甲"},
			//	new User {Name = @"Bb", Description = @"使用者 乙"},
			//	new User {Name = @"Cc", Description = @"使用者 丙"},
			//	new User {Name = @"Dd", Description = @"使用者 丁"}
			//};

			var list = new List<Food>
			{
				new Food 
				{
					Name = @"正宗排骨", 
					Description = @"超好吃排骨飯",
					Img = "frice.jpeg",
					Time = "10:00-23:00",
					Phone = "07-2556-3889",
					Addr = "高雄市正忠街100巷70號33樓",
					Score = 4.3F,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=%E6%AD%A3%E5%BF%A0%E6%8E%92%E9%AA%A8%E9%A3%AF",
					Introduction = "超級好吃正忠排骨飯",
					Lat = 22.6423298,
					Lng = 120.3279867
				},
				new Food 
				{
					Name = @"武廟甜不辣", 
					Description = @"超好吃甜不辣",
					Img = "tempura.jpg",
					Time = "10:00-23:00",
					Phone = "07-2556-3889",
					Addr = "高雄市正忠街100巷70號33樓",
					Score = 4.3F,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=%E6%AD%A6%E5%BB%9F%E7%94%9C%E4%B8%8D%E8%BE%A3",
					Introduction = "超級好吃正忠排骨飯",
					Lat = 22.6299013,
					Lng = 120.329613
				},
				new Food 
				{
					Name = @"阿婆冰", 
					Description = @"超好吃雪花冰",
					Img = "ice.jpeg",
					Time = "10:00-23:00",
					Phone = "07-2556-3889",
					Addr = "高雄市正忠街100巷70號33樓",
					Score = 4.3F,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=%E9%98%BF%E5%A9%86%E5%86%B0",
					Introduction = "超級好吃正忠排骨飯",
					Lat = 22.6268058,
					Lng = 120.2805582
				},
				new Food 
				{
					Name = @"武廟大川", 
					Description = @"超好吃傳統蛋糕",
					Img = "cake.jpg",
					Time = "10:00-23:00",
					Phone = "07-2556-3889",
					Addr = "高雄市正忠街100巷70號33樓",
					Score = 4.3F,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=%E6%AD%A6%E5%BB%9F%E5%A4%A7%E5%B7%9D",
					Introduction = "超級好吃正忠排骨飯",
					Lat = 22.6310115,
					Lng = 120.3250816
				}
			};

			var tableSource = new FoodTableSource(list);
			userTable.Source = tableSource;

			tableSource.FoodSelected += delegate (object sender, FoodSelectedEventArgs e)
			{

				WriteLine(e.SelectedFood.Name);
				SelectedFood = e.SelectedFood;
				//
				InvokeOnMainThread(() => {

					PerformSegue("moveToDetailViewSegue", this);

				});
			};

			userTable.ReloadData();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if(segue.Identifier == "moveToDetailViewSegue")
			{
				if(segue.DestinationViewController is DetailViewController)
				{
					var destViewController = segue.DestinationViewController as DetailViewController;

					// destViewController.SelectedUser = SelectedUser;
					destViewController.SelectedFood = SelectedFood;

				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class FoodTableSource : UITableViewSource
		{
			// CellView Identifier
			const string FoodViewCellViewIdentifier = @"FoodViewCell";

			// ctor. Model

			private List<Food> Food { get; set; }

			public FoodTableSource(IEnumerable<Food> food)
			{
				Food = new List<Food>();
				Food.AddRange(food);
			}

			// Model -> Controller -> View

			// Memory
			public override nint NumberOfSections(UITableView tableView)
			{
				return 1;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Food.Count;
			}

			// Controller -> View

			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				Food myClass = Food[indexPath.Row];

				FoodViewCell cell = tableView.DequeueReusableCell(FoodViewCellViewIdentifier) as FoodViewCell;

				cell.UpdateUI(myClass);

				return cell;
			}

			// View -> Controller

			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);

				Food food = Food[indexPath.Row];

				EventHandler<FoodSelectedEventArgs> handle = FoodSelected;

				if (null != handle)
				{

					var args = new FoodSelectedEventArgs { SelectedFood = food };

					handle(this, args);
				}
			}

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<FoodSelectedEventArgs> FoodSelected;

		}

		public class FoodSelectedEventArgs : EventArgs
		{
			public Food SelectedFood { get; set; }

		}

		//public class UserTableSource : UITableViewSource
		//{
		//	// CellView Identifier
		//	const string UserViewCellViewIdentifier = @"UserViewCell";

		//	// ctor. Model

		//	private List<User> Users { get; set; }

		//	public UserTableSource(IEnumerable<User> users)
		//	{
		//		Users = new List<User>();
		//		Users.AddRange(users);
		//	}

		//	// Model -> Controller -> View

		//	// Memory
		//	public override nint NumberOfSections(UITableView tableView)
		//	{
		//		return 1;
		//	}

		//	public override nint RowsInSection(UITableView tableview, nint section)
		//	{
		//		return Users.Count;
		//	}

		//	// Controller -> View

		//	public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		//	{
		//		User myClass = Users[indexPath.Row];

		//		UserViewCell cell = tableView.DequeueReusableCell(UserViewCellViewIdentifier) as UserViewCell;

		//		cell.UpdateUI(myClass);

		//		return cell;
		//	}

		//	// View -> Controller

		//	public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		//	{
		//		tableView.DeselectRow(indexPath, true);

		//		User user = Users[indexPath.Row];

		//		EventHandler<UserSelectedEventArgs> handle = UserSelected;

		//		if (null != handle)
		//		{

		//			var args = new UserSelectedEventArgs { SelectedUser = user };

		//			handle(this, args);
		//		}
		//	}

		//	/// <summary>
		//	/// 設計事件，回傳結果給呼叫端
		//	/// </summary>
		//	public event EventHandler<UserSelectedEventArgs> UserSelected;

		//}

		//public class UserSelectedEventArgs : EventArgs
		//{
		//	public User SelectedUser { get; set; }

		//}
	}
}

