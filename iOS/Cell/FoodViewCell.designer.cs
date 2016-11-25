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
	[Register ("FoodViewCell")]
	partial class FoodViewCell
	{
		[Outlet]
		UIKit.UIImageView imgFood { get; set; }

		[Outlet]
		UIKit.UILabel lblDescription { get; set; }

		[Outlet]
		UIKit.UILabel lblName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgFood != null) {
				imgFood.Dispose ();
				imgFood = null;
			}

			if (lblDescription != null) {
				lblDescription.Dispose ();
				lblDescription = null;
			}

			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}
		}
	}
}
