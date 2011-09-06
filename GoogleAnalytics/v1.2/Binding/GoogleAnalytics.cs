using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace GoogleAnalytics
{
	[BaseType (typeof (NSObject))]
	interface GANTracker {
		
		[Export ("debug")]
		bool Debug { get; set; }

		[Export ("dryRun")]
		bool DryRun { get; set; }

		[Static] [Export ("sharedTracker")]
		GANTracker SharedTracker { get; }

		[Export ("startTrackerWithAccountID:dispatchPeriod:delegate:")]
		void StartTracker (string accountId, int dispatchPeriod, [NullAllowed] GANTrackerDelegate ganDelegate);

		[Export ("stopTracker")]
		void StopTracker ();

		[Export ("trackPageview:withError:")]
		bool TrackPageview (string pageURL, out NSError error);

		[Export ("trackEvent:action:label:value:withError:")]
		bool TrackEvent (string category, string action, string label, int value, out NSError error);

		[Export ("setCustomVariableAtIndex:name:value:scope:withError:")]
		bool SetCustomVariableWithScope (int index, string name, string value, int scope, out NSError error);

		[Export ("setCustomVariableAtIndex:name:value:withError:")]
		bool SetCustomVariable (int index, string name, string value, out NSError error);

		[Export ("getVisitorCustomVarAtIndex:")]
		string GetVisitorCustomVar(int index);

		[Export ("addTransaction:totalPrice:storeName:totalTax:shippingCost:withError:")]
		bool AddTransaction (string orderId, double totalPrice, string storeName, double totalTax, double shippingCost, out NSError error);

		[Export ("addItem:itemSKU:itemPrice:itemCount:itemName:itemCategory:withError:")]
		bool AddItem (string orderID, string itemSKU, double itemPrice, double itemCount, string itemName, string itemCategory, out NSError error);

		[Export ("trackTransactions:")]
		bool TrackTransactions (out NSError error);

		[Export ("clearTransactions:")]
		bool ClearTransactions (out NSError error);

		[Export ("dispatch")]
		bool Dispatch ();

	}

	[BaseType (typeof (NSObject))]
	interface GANTrackerDelegate {
		
		[Export ("trackerDispatchDidComplete:eventsDispatched:eventsFailedDispatch:")]
		void DispatchCompleted (GANTracker tracker, int eventsDispatched, int eventsFailedDispatch);

	}
}
