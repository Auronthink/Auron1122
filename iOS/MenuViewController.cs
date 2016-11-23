using System;
using System.Collections.Generic;
using UIKit;

namespace Auron.iOS
{
	public partial class MenuViewController : UIViewController
	{
		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class UserTableSource : UITableViewSource
		{
			// CellView Identifier
			const string UserViewCellCellViewIdentifier = @"UserViewCell";

			// ctor. Model

			private List<User> Users { get; set; }

			public UserTableSource(IEnumerable<User> users)
			{
				Users = new List<User>();
				Users.AddRange(users);
			}

			// Model -> Controller -> View

			// Memory
			public override nint NumberOfSections(UITableView tableView)
			{
				return 1;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Users.Count;
			}

			// Controller -> View

			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				UserViewCell cell = tableView.DequeueReusableCell(UserViewCellCellViewIdentifier) as UserViewCell;

				return cell;
			}

			// View -> Controller

			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				User user = Users[indexPath.Row];
			}

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<UserSelectedEventArgs> UserSelected;

		}

		public class UserSelectedEventArgs : EventArgs
		{
			public User SelectedUser { get; set; }

		}
	}
}

