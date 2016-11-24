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
				PerformSegue("moveToWebViewSegue", this);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

