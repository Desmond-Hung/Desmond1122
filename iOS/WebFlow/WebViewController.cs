using System;
using Foundation;
using UIKit;

namespace Desmond.iOS
{
	public partial class WebViewController : UIViewController
	{
		private string DefaultURL = "https://www.google.com.tw/?gws_rd=ssl";

		public WebViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			btnGo.TouchUpInside += (sender, e) => 
			{
				ClickGo();
			};
			txtURL.TouchUpInside += (sender, e) =>
			{
				txtURL.Text = "";
			};
			txtURL.Text = DefaultURL;
			GoLink(this.DefaultURL);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private void ClickGo()
		{ 
			var web_URL = txtURL.Text;
			GoLink(web_URL);
		}

		private void GoLink(string web_URL)
		{
			this.viewWeb.LoadRequest(new NSUrlRequest(new NSUrl(web_URL)));
		}
	}
}

