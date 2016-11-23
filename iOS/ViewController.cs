using System;
using System.Threading.Tasks;
using UIKit;

namespace Desmond.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// 另外開Thread跑程式
			Task.Run(() =>
			{
				Task.Delay(2000); //假裝做事
				InvokeOnMainThread(() => { //呼叫主Thread進行換頁
					PerformSegue("moveToLoginViewSegue", this);
				});
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
