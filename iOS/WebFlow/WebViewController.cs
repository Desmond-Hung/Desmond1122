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

			// 利用WebView連網頁，每次網址變化都會觸發ShouldStartLoad，再利用網址的變化來分析字串，啟動Local端Function
			viewWeb.LoadHtmlString(@"
			<html>
				<head>
					<title>Local String</title>
					<style type='text/css'>p{font-family : Verdana; color : purple }</style>
					<script language='JavaScript'> 
						function msg(){ 
							window.location = 'shirly://Hi'  
						}
					</script>
				</head>
				<body>
					<p>Hello World!</p><br />
					<button type='button' onclick='msg()' text='Hi'>Hi</button>
				</body>
			</html>", null);

			viewWeb.ShouldStartLoad = delegate (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
			{
				Console.WriteLine("ShouldStartLoad");
				var requestString = request.Url.AbsoluteString;
				var components = requestString.Split(new[] { @"://" }, StringSplitOptions.None);
				if (components.Length > 1 && components[0].ToLower() == @"shirly".ToLower())
				{
					if (components[1] == @"Hi")
					{
						UIAlertController alert = UIAlertController.Create(@"Hi Title", @"當然是世界好", UIAlertControllerStyle.Alert);

						UIAlertAction okAction = UIAlertAction.Create(@"OK", UIAlertActionStyle.Default, (action) =>
						{
							Console.WriteLine(@"OK");
						});
						alert.AddAction(okAction);
						UIAlertAction cancelAction = UIAlertAction.Create(@"Cancel", UIAlertActionStyle.Default, (action) =>
						{
							Console.WriteLine(@"Cancel");
						});
						alert.AddAction(cancelAction);

						PresentViewController(alert, true, null);
						return false;
					}
				}
				return true;
			};

			btnGo.TouchUpInside += (sender, e) => 
			{
				ClickGo();
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private void ClickGo()
		{ 
			var web_URL = txtURL.Text;
			if (web_URL != "")
			{ 
				GoLink(web_URL);
			}
		}

		private void GoLink(string web_URL)
		{
			this.viewWeb.LoadRequest(new NSUrlRequest(new NSUrl(web_URL)));
		}
	}
}

