using System;
using CoreLocation;
using UIKit;
using CoreLocation;
using CoreGraphics;
using MapKit;

namespace Desmond.iOS
{
	public partial class MapViewController : UIViewController
	{
		public Restaurant SelectedItem { get; set; }

		public MapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			openMap1();
			SetButton();
		}

		private void openMap1()
		{ 
			// 直接複製來開啟Map的語法
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();
			// 顯示User位置
			viewMap.ShowsUserLocation = true;
			//星下點
			if (SelectedItem.Location2D != null)
			{ 
				var myLoc = new CLLocationCoordinate2D(SelectedItem.Location2D.Lat, SelectedItem.Location2D.Lng);
				viewMap.CenterCoordinate = myLoc;
				var mapRegion = MKCoordinateRegion.FromDistance(myLoc, 1000, 1000);
				viewMap.Region = mapRegion;
				viewMap.AddAnnotations(new MKPointAnnotation()
				{
					Title = SelectedItem.Name,
					Coordinate = myLoc,
					Subtitle = String.Format("({0}, {1})", SelectedItem.Location2D.Lat, SelectedItem.Location2D.Lng)
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

		public void SetButton()
		{
			this.btnBack.Layer.CornerRadius = 8;
			this.btnBack.Layer.ShadowColor = UIColor.Black.ColorWithAlpha((float)0.2).CGColor; // 陰影顏色
			this.btnBack.Layer.ShadowOffset = new CGSize(0, 5); // 陰影偏移
			this.btnBack.Layer.ShadowOpacity = (float)0.8; // 陰影透明
			btnBack.TouchUpInside += (sender, e) =>
			{
				this.DismissViewController(true, null);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

