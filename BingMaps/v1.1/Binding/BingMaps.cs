using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using System.Drawing;

namespace BingMaps
{
	[BaseType (typeof (NSObject))]
	interface BMEntity {
		
		[Export ("addressDictionary")]
		NSDictionary AddressDictionary { get;  }

		[Export ("addressLine")]
		string AddressLine { get;  }

		[Export ("adminDistrict")]
		string AdminDistrict { get;  }

		[Export ("adminDistrict2")]
		string AdminDistrict2 { get;  }

		[Export ("locality")]
		string Locality { get;  }

		[Export ("postalCode")]
		string PostalCode { get;  }

		[Export ("countryRegion")]
		string CountryRegion { get;  }

		[Export ("formattedAddress")]
		string FormattedAddress { get;  }

		[Export ("initWithCoordinate:bingAddressDictionary:")]
		IntPtr Constructor (CLLocationCoordinate2D coordinate, NSDictionary addressDictionary);  
	}
	
	// Need to create BMGeometery

	[BaseType (typeof (UIView), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (BMMapViewDelegate)})]
	interface BMMapView {
		
		#region Delegates
		
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		BMMapViewDelegate Delegate { get; set; }
		
		#endregion
		
		#region Constructor
		
		[Export ("initWithFrame:")]
		IntPtr Constructor (RectangleF frame);
		
		#endregion
		
		#region Properties
		
		[Export ("mapMode")]
		BMMapMode MapMode { get; set;  }

		[Export ("region")]
		BMCoordinateRegion Region { get; set;  }

		[Export ("zoomEnabled")]
		bool ZoomEnabled { get; set;  }

		[Export ("scrollEnabled")]
		bool ScrollEnabled { get; set;  }

		[Export ("centerCoordinate")]
		CLLocationCoordinate2D CenterCoordinate { get; set;  }

		[Export ("userLocation")]
		BMUserLocation UserLocation { get;  }

		[Export ("userLocationVisible")]
		bool UserLocationVisible { [Bind ("isUserLocationVisible")] get;  }

		[Export ("markers")]
		BMMarker[] Markers { get;  }

		[Export ("selectedMarkers")]
		BMMarker[] SelectedMarkers { get; set;  }

		[Export ("markerVisibleRect")]
		RectangleF MarkerVisibleRect { get;  }
		
		#endregion
		
		#region Methods
		
		[Export ("setRegion:animated:")]
		void SetRegion (BMCoordinateRegion region, bool animated);

		[Export ("setCenterCoordinate:animated:")]
		void SetCenterCoordinate (CLLocationCoordinate2D coordinate, bool animated);

		[Export ("regionThatFits:")]
		BMCoordinateRegion RegionThatFits (BMCoordinateRegion region);

		[Export ("convertCoordinate:toPointToView:")]
		PointF ConvertCoordinate (CLLocationCoordinate2D coordinate, UIView view);

		[Export ("convertPoint:toCoordinateFromView:")]
		CLLocationCoordinate2D ConvertPoint(PointF point, UIView view);

		[Export ("convertRegion:toRectToView:")]
		RectangleF ConvertRegion (BMCoordinateRegion region, UIView view);

		[Export ("convertRect:toRegionFromView:")]
		BMCoordinateRegion ConvertRect (RectangleF rect, UIView view);

		[Export ("showsUserLocation")]
		bool ShowsUserLocation { get; set; }

		[Export ("addMarker:")]
		void AddMarker (BMMarker marker);

		[Export ("addMarkers:")]
		void AddMarkers (BMMarker[] markers);

		[Export ("removeMarker:")]
		void RemoveMarker (BMMarker marker);

		[Export ("removeMarkers:")]
		void RemoveMarkers (BMMarker[] markers);

		[Export ("viewForMarker:")]
		BMMarkerView ViewForMarker (BMMarker marker);

		[Export ("dequeueReusableMarkerViewWithIdentifier:")]
		BMMarkerView DequeueReusableMarkerView (string identifier);

		[Export ("selectMarker:animated:")]
		void SelectMarker (BMMarker marker, bool animated);

		[Export ("deselectMarker:animated:")]
		void DeselectMarker (BMMarker marker, bool animated);
		
		#endregion
		 
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface BMMapViewDelegate {
		
		[Export ("mapView:regionWillChangeAnimated:"), EventArgs("RegionWillChange")]
		void RegionWillChange (BMMapView mapView, bool animated);
		
		[Export ("mapView:regionDidChangeAnimated:"), EventArgs("RegionDidChange")]
		void RegionDidChange (BMMapView mapView, bool animated);
		
		[Export ("mapViewWillStartLoadingMap:"), EventArgs("WillStartLoadingMap")]
		void WillStartLoadingMap (BMMapView mapView);
		
		[Export ("mapViewDidFinishLoadingMap:"),EventArgs("DidFinishLoadingMap")]
		void DidFinishLoadingMap (BMMapView mapView);
		
		[Export ("mapViewDidFailLoadingMap:withError:"), EventArgs("DidFailLoadingMap")]
		void DidFailLoadingMap (BMMapView mapView, NSError error);
		
		//[Export ("mapView:viewForMarker:"), DelegateName("ViewForMarkerA"), DefaultValue(null)]
		//BMMarkerView ViewForMarker (BMMapView mapView, BMMarker marker);

		[Export ("mapView:didAddMarkerViews:"), EventArgs("DidAddMarkerViews")]
		void DidAddMarkerViews (BMMapView mapView, BMMarker[] views);
		
		[Export ("mapView:markerView:calloutAccessoryControlTapped:"), EventArgs("MarkerViewCalloutAccessoryControlTapped")]
		void MarkerViewCalloutAccessoryControlTapped (BMMapView mapView, BMMarkerView view, UIControl control);

	}
	
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface BMMarker {
		[Abstract]
		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate ();

		[Export ("title")]
		string Title ();

		[Export ("subtitle")]
		string Subtitle ();

	}
	
	
	[BaseType (typeof (UIView))]
	interface BMMarkerView {
		[Export ("reuseIdentifier")]
		string ReuseIdentifier { get;  }

		[Export ("BMMarker")]
		BMMarker Marker { get; set;  }

		[Export ("image")]
		UIImage Image { get; set;  }

		[Export ("centerOffset")]
		PointF CenterOffset { get; set;  }

		[Export ("calloutOffset")]
		PointF CalloutOffset { get; set;  }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set;  }

		[Export ("selected")]
		bool Selected { [Bind ("isSelected")] get; set;  }

		[Export ("canShowCallout")]
		bool CanShowCallout { get; set;  }

		[Export ("calloutAccessoryView1")]
		UIView CalloutAccessoryView1 { get; set;  }

		[Export ("calloutAccessoryView2")]
		UIView CalloutAccessoryView2 { get; set;  }

		[Export ("initWithMarker:reuseIdentifier:")]
		IntPtr Constructor (BMMarker marker, string reuseIdentifier);

		[Export ("prepareForReuse")]
		void PrepareForReuse ();

		[Export ("setSelected:animated:")]
		void SetSelected (bool selected, bool animated);

	}
	

	[BaseType (typeof (BMMarkerView))]
	interface BMPushpinView {
		[Export ("animatesDrop")]
		bool AnimatesDrop { get; set;  }

		[Export ("BMPushpinColorpinColor")]
		BMPushpinColor PinColor ();

	}
	
	
	[BaseType (typeof (NSObject), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (BMReverseGeocoderDelegate)})]

	interface BMReverseGeocoder {
		
		#region Delegates
		
		[Export ("delegate"), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		BMReverseGeocoderDelegate Delegate { get; set; }
		
		#endregion

		[Export ("coordinate")]
		CLLocationCoordinate2D Coordinate { get;  }

		[Export ("entity")]
		BMEntity Entity { get;  }

		[Export ("querying")]
		bool Querying { [Bind ("isQuerying")] get;  }

		[Export ("initWithCoordinate:")]
		IntPtr Constructor (CLLocationCoordinate2D coordinate);

		[Export ("start")]
		void Start ();

		[Export ("cancel")]
		void Cancel ();

	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface BMReverseGeocoderDelegate {
		
		[Abstract]
		[Export ("reverseGeocoder:didFindEntity:"), EventArgs("DidFindEntity")]
		void DidFindEntity (BMReverseGeocoder geocoder, BMEntity entity);

		[Abstract]
		[Export ("reverseGeocoder:didFailWithError:"), EventArgs("DidFailWithError")]
		void DidFailWithError (BMReverseGeocoder geocoder, NSError error);
	}

	// Create BMTypes.
	
	
	[BaseType (typeof (NSObject))]
	interface BMUserLocation {
		[Export ("updating")]
		bool Updating { [Bind ("isUpdating")] get;  }

		[Export ("location")]
		CLLocation Location { get;  }

		[Export ("title")]
		string Title { get; set;  }

		[Export ("subtitle")]
		string Subtitle { get; set;  }

	}
	
	

}

