using System;
using MonoTouch.CoreLocation;

namespace BingMaps
{
	public enum BMMapMode 
	{
		BMMapModeRoad = 0,
		BMMapModeAerial,
    	BMMapModeAerialWithLabels
	}
	
	public enum BMErrorCode 
	{
		BMErrorUnknown = 1,
		BMErrorServerFailure,
		BMErrorLoadingThrottled,
		BMErrorEntityNotFound,
		BMErrorAuthenticationFailure
	}
	
	public enum BMPushpinColor {
		BMPushpinColorOrange = 0,
		BMPushpinColorGreen,
		BMPushpinColorRed,
		BMPushpinColorBlue,
		BMPushpinColorYellow, 
		BMPushpinColorPurple 
	}
	
	public struct BMCoordinateRegion
	{
		public CLLocationCoordinate2D Center;
		public BMCoordinateSpan Span;	
	}
	
	public struct BMCoordinateSpan
	{
		public double LatitudeDelta;
		public double LongitudeDelta;
	}
	
	
	
}

