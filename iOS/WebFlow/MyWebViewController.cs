using System;

using UIKit;

using static System.Console;
using Foundation;

namespace Auron.iOS
{
	public partial class MyWebViewController : UIViewController
	{
		public string webUrl { get; set; }

		public MyWebViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			var beginBtnGoBottomConstraint = btnGoBottomConstraint.Constant;

			// Controller下的View，容器的概念
			// this.View

			myWebView.LoadRequest(new NSUrlRequest(new NSUrl(webUrl)));

			// loadRemote
			btnGo.TouchUpInside += (sender, e) =>
			{
				if (txtURL.IsFirstResponder)
				{
					txtURL.ResignFirstResponder();
				}

				myWebView.LoadRequest(new NSUrlRequest(new NSUrl(txtURL.Text)));
				// myWebView.LoadRequest(new NSUrlRequest(new NSUrl(@"https://www.google.com")));
			};

			#region CallNatived
			//UIKeyboard.Notifications.ObserveWillChangeFrame((sender, e) =>
			//{

			//	var beginRect = e.FrameBegin;
			//	var endRect = e.FrameEnd;

			//	WriteLine($"ObserveWillChangeFrame endRect:{endRect.Height}");

			//	InvokeOnMainThread(() =>
			//   {
			//	   UIView.Animate(1, () =>
			//	   {
			//		   btnGoBottomConstraint.Constant = endRect.Height + 5;
			//		   this.View.LayoutIfNeeded();
			//	   });

			//   });
			//});

			//UIKeyboard.Notifications.ObserveWillHide((sender, e) =>
			//{
			//	InvokeOnMainThread(() =>
			//   	{
			//		   UIView.Animate(1, () =>
			//		   {
			//			   btnGoBottomConstraint.Constant = beginBtnGoBottomConstraint;
			//			   this.View.LayoutIfNeeded();
			//		   });
			//	   });
			//});

			//// call native
			//myWebView.LoadHtmlString(@"
			//<html>
			//	<head>
			//		<title>Local String</title>
			//		<style type='text/css'>p{font-family : Verdana; color : purple }</style>
			//		<script language='JavaScript'> 
			//			function msg(){ 
			//				window.location = 'shirly://Hi'  
			//			}
			//		</script>
			//	</head>
			//	<body>
			//		<p>Hello World!</p><br />
			//		<button type='button' onclick='msg()' text='Hi'>Hi</button>
			//	</body>
			//</html>", null);

			//myWebView.ShouldStartLoad =
			//	delegate (UIWebView webView,
			//		NSUrlRequest request,
			//		UIWebViewNavigationType navigationType)
			//	{

			//		var requestString = request.Url.AbsoluteString;

			//		var components = requestString.Split(new[] { @"://" }, StringSplitOptions.None);

			//		if (components.Length > 1 && components[0].ToLower() == @"shirly".ToLower())
			//		{

			//			if (components[1] == @"Hi")
			//			{

			//				UIAlertController alert = UIAlertController.Create(@"Hi Title", @"當然是世界好", UIAlertControllerStyle.Alert);


			//				UIAlertAction okAction = UIAlertAction.Create(@"OK", UIAlertActionStyle.Default, (action) =>
			//				{
			//					Console.WriteLine(@"OK");
			//				});
			//				alert.AddAction(okAction);


			//				UIAlertAction cancelAction = UIAlertAction.Create(@"Cancel", UIAlertActionStyle.Default, (action) =>
			//				{
			//					Console.WriteLine(@"Cancel");
			//				});
			//				alert.AddAction(cancelAction);

			//				PresentViewController(alert, true, null);


			//				return false;
			//			}

			//		}

			//		return true;

			//	};
 			#endregion

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

