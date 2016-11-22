using System;

using UIKit;

namespace Auron.iOS
{
	public partial class MyWebViewController : UIViewController
	{
		public MyWebViewController(IntPtr handle) : base(handle)// 這樣就是Storyboard去binding，而不是從xib
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
	}
}

