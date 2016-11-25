using System;

using UIKit;

namespace Desmond.iOS
{
	public partial class DetailViewController : UIViewController
	{
		public User SelectedUser { get; internal set; }
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = this.SelectedUser.Name;

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
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier == "moveToWebViewSegue")
			{
				if (segue.DestinationViewController is WebViewController)
				{
					var destViewController = segue.DestinationViewController as DetailViewController;
				}
			}
			else if (segue.Identifier == "moveToMapViewSegue")
			{
				if (segue.DestinationViewController is MapViewController)
				{ 
					var destViewController = segue.DestinationViewController as MapViewController;
					destViewController.myLocation = new Location() { Lat = 22.6267495, Lng = 120.323166 };
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

