using System;

using UIKit;

using CoreGraphics;
using CoreLocation;
using MapKit;

namespace Auron.iOS
{
	public partial class MyMapViewController : UIViewController
	{
		public MyLocation DisplayLocation { get; set; }

		public MyMapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// 星下點
			var mapCenter = new CLLocationCoordinate2D( DisplayLocation.Lat, DisplayLocation.Lng );
			//var mapCenter = new CLLocationCoordinate2D(22.6423298, 120.3279867);


			myMapView.CenterCoordinate = mapCenter;

			var mapRegion = MKCoordinateRegion.FromDistance(mapCenter, 4000, 4000);
			myMapView.Region = mapRegion;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

