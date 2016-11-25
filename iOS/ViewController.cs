using System;
using System.Threading.Tasks;

using UIKit;
using static System.Console;

namespace Auron.iOS
{
	public partial class ViewController : UIViewController
	{
		//int count = 1;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Open another Thread to Run
			Task.Run(() => {
				Task.Delay(4000);
				InvokeOnMainThread(() =>
				{
					PerformSegue("moveToLoginViewSegue", this);
				});
			});


			//helloBtn.TouchUpInside += (sender, e) => 
			//{
			//	PerformSegue("moveToLoginViewSegue", this);
			//};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
