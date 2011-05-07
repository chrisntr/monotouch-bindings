using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using BingMaps;
using System.Drawing;

namespace MapControlApp
{
	public partial class MapViewController : UIViewController
	{
		#region Constructors
		
		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code
		
		public MapViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}

		[Export ("initWithCoder:")]
		public MapViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}

		public MapViewController () : base ("MapViewController", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion

		BMMapView mapView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			mapView = new BMMapView(new RectangleF(0f, 0f, 320f, 480f));
			
			mapView.DidFinishLoadingMap += (sender, e) => {
				Console.WriteLine ("Map finished loading...");
			};
			mapView.ShowsUserLocation = true;
			this.View.AddSubview(mapView);
			
			var label = new UILabel();
			label.Frame = new RectangleF(0f, 300f, 320f, 40f);
			label.TextAlignment = UITextAlignment.Center;
			label.BackgroundColor = UIColor.Clear;
			label.Text = "Hello Bing from MonoTouch";
			this.View.AddSubview(label);
			
		}
	}
}

