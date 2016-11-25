﻿using System;
using CoreLocation;
using UIKit;
using CoreLocation;
using CoreGraphics;
using MapKit;

namespace Desmond.iOS
{
	public partial class MapViewController : UIViewController
	{
		public Location myLocation { get; set; }

		public MapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			openMap1();
		}

		private void openMap1()
		{ 
			// 直接複製來開啟Map的語法
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();
			// 顯示User位置
			viewMap.ShowsUserLocation = true;
			//星下點
			if (myLocation != null)
			{ 
				var myLoc = new CLLocationCoordinate2D(myLocation.Lat, myLocation.Lng);
				viewMap.CenterCoordinate = myLoc;
				var mapRegion = MKCoordinateRegion.FromDistance(myLoc, 4000, 4000);
				viewMap.Region = mapRegion;
				viewMap.AddAnnotations(new MKPointAnnotation()
				{
					Title = "JetFusion",
					Coordinate = myLoc,
					Subtitle = String.Format("({0}, {1})", myLocation.Lat, myLocation.Lng)
				});
			}


			// 設定地圖中心與顯示範圍
			//if (SelectedLocation != null)
			//{
			//	CLLocationCoordinate2D location = new CLLocationCoordinate2D(SelectedLocation.Latitude, SelectedLocation.Longitude);
			//	var mapRegion = MKCoordinateRegion.FromDistance(location, 1000, 1000);
			//	viewMap.Region = mapRegion;
			//	// 增加圖標
			//	viewMap.AddAnnotations(new MKPointAnnotation()
			//	{
			//		Title = SelectedLocation.Name,
			//		Coordinate = location,
			//		Subtitle = String.Format("({0}, {1})", location.Latitude, location.Longitude)
			//	});
			//}
			//else
			//{
			//	var alert = UIAlertController.Create("Error", "Failed to get location data from previous page.", UIAlertControllerStyle.Alert);
			//	alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			//	PresentViewController(alert, true, null);
			//}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

