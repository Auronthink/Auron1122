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

			// loadRemote
			btnGo.TouchUpInside += (sender, e) =>
			{
				if (txtURL.IsFirstResponder)
				{
					txtURL.ResignFirstResponder();
				}

				// myWebView.LoadRequest(new NSUrlRequest(new NSUrl(txtURL.Text)));
				myWebView.LoadRequest(new NSUrlRequest(new NSUrl(@"https://www.google.com")));
			};

			UIKeyboard.Notifications.ObserveWillChangeFrame((sender, e) =>
			{

				var beginRect = e.FrameBegin;
				var endRect = e.FrameEnd;

				WriteLine($"ObserveWillChangeFrame endRect:{endRect.Height}");

				InvokeOnMainThread(() =>
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

			// loadLocal
			myWebView.LoadHtmlString(@"
			<html>
				<head>
				<title>Local String</title>
				<style type='text/css'>p{font-family : Verdana; color : purple }</style>
				<script language='JavaScript'> function msg(){alert('Hi !');}</script>
				</head>
				<body>
				<p>Hello World!</p><br />
				<button type='button' onclick='msg()' text='Hi'>Hi</button>
				</body>
			</html>", null);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

