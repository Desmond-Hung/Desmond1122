using System;
using CoreGraphics;
using UIKit;

namespace Desmond.iOS
{
	public partial class DetailViewController : UIViewController
	{
		public Restaurant SelectedItem { get; internal set; }
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "餐廳資訊";

			btnWeb.TouchUpInside += (sender, e) =>
			{
				InvokeOnMainThread(() =>
				{
					PerformSegue("moveToWebViewSegue", this);
				});
			};
			btnMap.TouchUpInside += (sender, e) =>
			{
				InvokeOnMainThread(() =>
				{
					PerformSegue("moveToMapViewSegue", this);
				});
			};
			SetBackground();
			ShowDetail();
		}

		public void ShowDetail()
		{ 
			this.imgPhoto.Image = UIImage.FromFile("Images/" + SelectedItem.Image);
			this.txtName.Text = SelectedItem.Name;
			this.btnMap.SetTitle(SelectedItem.Address, UIControlState.Normal);
			this.txtPhone.Text = SelectedItem.Phone;
		}

		public void SetBackground()
		{ 
			this.viewBackground.BackgroundColor = UIColor.White; // 背景色
			this.viewBackground.Layer.CornerRadius = 8; // 圓角
			this.viewBackground.Layer.ShadowColor = UIColor.Black.ColorWithAlpha((float)0.2).CGColor; // 陰影顏色
			this.viewBackground.Layer.ShadowOffset = new CGSize(0, 5); // 陰影偏移
			this.viewBackground.Layer.ShadowOpacity = (float)0.8; // 陰影透明
			this.btnWeb.Layer.CornerRadius = 8;
			this.btnWeb.Layer.ShadowColor = UIColor.Black.ColorWithAlpha((float)0.2).CGColor; // 陰影顏色
			this.btnWeb.Layer.ShadowOffset = new CGSize(0, 5); // 陰影偏移
			this.btnWeb.Layer.ShadowOpacity = (float)0.8; // 陰影透明
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier == "moveToWebViewSegue")
			{
				if (segue.DestinationViewController is WebViewController)
				{
					var destViewController = segue.DestinationViewController as WebViewController;
					destViewController.SearchTarget = SelectedItem.Name;
				}
			}
			else if (segue.Identifier == "moveToMapViewSegue")
			{
				if (segue.DestinationViewController is MapViewController)
				{ 
					var destViewController = segue.DestinationViewController as MapViewController;
					destViewController.SelectedItem = SelectedItem;
				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

