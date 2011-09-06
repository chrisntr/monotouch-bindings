using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using GoogleAnalytics;

namespace GoogleAnalyticsSample
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
	
	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		DashboardViewController dvc;
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			GANTracker.SharedTracker.Debug = true;
			
			GANTracker.SharedTracker.StartTracker("UA-00000000-1", 10, null);
			
			NSError error;
			if(!GANTracker.SharedTracker.SetCustomVariable(1, "iPhone1", "iv2", out error))
			{
				Console.WriteLine ("Error setting custom variable: " + error.LocalizedDescription);
				// Handle error here
			}
 
			if(!GANTracker.SharedTracker.TrackEvent("my_category", "my_action", "my_label", -1, out error))
			{
				Console.WriteLine ("Error tracking event: " + error.LocalizedDescription);
				
				// Handle error here	
			}
			
			if(!GANTracker.SharedTracker.TrackPageview("/app_entry_point", out error))
			{
				Console.WriteLine ("Error tracking event: " + error.LocalizedDescription);
				
				// Handle error here
			}

			dvc = new DashboardViewController();
			
			window.RootViewController = dvc;
			
			window.MakeKeyAndVisible ();
	
			return true;
		}
	
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
		
		~AppDelegate()
	    {
			GANTracker.SharedTracker.StopTracker();
	    }
	}
}

