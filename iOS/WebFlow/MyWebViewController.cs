using System;

using UIKit;

using static System.Console;
using Foundation;

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
			var beginBtnGoBottomConstraint = btnGoBottomConstraint.Constant;

			// Controller下的View，容器的概念
			// this.View



			btnGo.TouchUpInside += (sender, e) => {
				if (txtURL.IsFirstResponder)
				{
					txtURL.ResignFirstResponder();
				}
				 
				myWebView.LoadRequest(new NSUrlRequest(new NSUrl(txtURL.Text)));
			};

			UIKeyboard.Notifications.ObserveWillChangeFrame((sender, e) =>
			{

				var beginRect = e.FrameBegin;
				var endRect = e.FrameEnd;

				WriteLine($"ObserveWillChangeFrame endRect:{endRect.Height}");

				InvokeOnMainThread( () => 
				{
					UIView.Animate(1, () =>
					{
						btnGoBottomConstraint.Constant = endRect.Height + 5;
						this.View.LayoutIfNeeded();
					});

				});
			});

			UIKeyboard.Notifications.ObserveWillHide((sender, e) =>
			{
				InvokeOnMainThread(() =>
			   	{
				   UIView.Animate(1, () =>
				   {
					   btnGoBottomConstraint.Constant = beginBtnGoBottomConstraint;
					   this.View.LayoutIfNeeded();
				   });
			   });
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

