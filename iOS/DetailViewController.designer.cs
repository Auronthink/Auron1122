// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Auron.iOS
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton btnMap { get; set; }

		[Outlet]
		UIKit.UIButton btnWeb { get; set; }

		[Outlet]
		UIKit.UIImageView imgFood { get; set; }

		[Outlet]
		UIKit.UILabel lblAddr { get; set; }

		[Outlet]
		UIKit.UILabel lblDescription { get; set; }

		[Outlet]
		UIKit.UILabel lblName { get; set; }

		[Outlet]
		UIKit.UILabel lblPhone { get; set; }

		[Outlet]
		UIKit.UILabel lblScore { get; set; }

		[Outlet]
		UIKit.UILabel lblTime { get; set; }

		[Outlet]
		UIKit.UILabel lblWebUrl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblPhone != null) {
				lblPhone.Dispose ();
				lblPhone = null;
			}

			if (lblTime != null) {
				lblTime.Dispose ();
				lblTime = null;
			}

			if (btnMap != null) {
				btnMap.Dispose ();
				btnMap = null;
			}

			if (btnWeb != null) {
				btnWeb.Dispose ();
				btnWeb = null;
			}

			if (imgFood != null) {
				imgFood.Dispose ();
				imgFood = null;
			}

			if (lblAddr != null) {
				lblAddr.Dispose ();
				lblAddr = null;
			}

			if (lblDescription != null) {
				lblDescription.Dispose ();
				lblDescription = null;
			}

			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (lblScore != null) {
				lblScore.Dispose ();
				lblScore = null;
			}

			if (lblWebUrl != null) {
				lblWebUrl.Dispose ();
				lblWebUrl = null;
			}
		}
	}
}
