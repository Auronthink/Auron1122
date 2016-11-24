using System;

using UIKit;

namespace Auron.iOS
{
	public partial class DetailViewController : UIViewController
	{
		public User SelectedUser { set; get; }
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = SelectedUser.Name;

			btnWeb.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToWebViewSegue", this);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

