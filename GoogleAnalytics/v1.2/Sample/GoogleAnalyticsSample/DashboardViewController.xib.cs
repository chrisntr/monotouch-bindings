using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using GoogleAnalytics;

namespace GoogleAnalyticsSample
{
	public partial class DashboardViewController : UIViewController
	{
		#region Constructors
		
		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code
		
		public DashboardViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		[Export ("initWithCoder:")]
		public DashboardViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		public DashboardViewController () : base ("DashboardViewController", null)
		{
			Initialize ();
		}
		
		void Initialize ()
		{
		}
		
		#endregion
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			NSError error;
			if(!GANTracker.SharedTracker.TrackPageview("/dashboard", out error))
			{
				// Handle error here
			}
			
			button.TouchUpInside += (sender, e) => {
				
				button.SetTitle("Purchased!", UIControlState.Normal);
				
				var orderId = Guid.NewGuid();
				
				GANTracker.SharedTracker.AddTransaction(orderId.ToString(), 798, "Xamarin Store", 0, 0, out error);
				if(error != null) 
				{
					// Handle error	
				}
				
				GANTracker.SharedTracker.AddItem(orderId.ToString(), "SKU001", 399, 1, "Mono for Android", "Xamarin", out error);
				GANTracker.SharedTracker.AddItem(orderId.ToString(), "SKU002", 399, 1, "MonoTouch", "Xamarin", out error);
				
				
				if (true /* purchase is confirmed */)
				{	
					GANTracker.SharedTracker.TrackTransactions(out error);
				} 
				else
				{
				    // The purchase was denied or failed in some way.  We need to clear out
				    // any data we've already put in the Ecommerce buffer.
				    GANTracker.SharedTracker.ClearTransactions(out error);
				}
				
			};
		}
	}
}

