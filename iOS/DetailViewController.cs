using System;

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

			ShowDetail();
		}

		public void ShowDetail()
		{ 
			this.imgPhoto.Image = UIImage.FromFile("Images/" + SelectedItem.Image);
			this.txtName.Text = SelectedItem.Name;
			this.btnMap.SetTitle(SelectedItem.Address, UIControlState.Normal);
			this.txtPhone.Text = SelectedItem.Phone;
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

