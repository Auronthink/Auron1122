using System;

using UIKit;

namespace Auron.iOS
{
	public partial class DetailViewController : UIViewController
	{
		// public User SelectedUser { set; get; }
		public Food SelectedFood { set; get; }

		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = SelectedFood.Name;

			#region Food Content
			lblName.Text = SelectedFood.Name;
			lblDescription.Text = SelectedFood.Description;
			imgFood.Image = UIImage.FromFile(SelectedFood.Img);
			lblAddr.Text = SelectedFood.Addr;
			lblScore.Text = SelectedFood.Score.ToString();
			lblWebUrl.Text = SelectedFood.Url;
			lblPhone.Text = SelectedFood.Phone;
			lblTime.Text = SelectedFood.Time;
			#endregion


			btnWeb.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToWebViewSegue", this);
			};

			btnMap.TouchUpInside += (sender, e) => 
			{
				PerformSegue("moveToMapViewSegue", this);
			};


		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier == "moveToMapViewSegue")
			{
				if (segue.DestinationViewController is MyMapViewController)
				{
					var destViewController = segue.DestinationViewController as MyMapViewController;


					var loc = new MyLocation { Lat = SelectedFood.Lat, Lng = SelectedFood.Lng };

					destViewController.DisplayLocation = loc;

				}
			}

			if (segue.Identifier == "moveToWebViewSegue")
			{
				if (segue.DestinationViewController is MyWebViewController)
				{
					var destViewController = segue.DestinationViewController as MyWebViewController;

					destViewController.webUrl = SelectedFood.Url;

				}
			}
		}
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

