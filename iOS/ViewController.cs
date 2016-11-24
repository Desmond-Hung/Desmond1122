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
				Console.WriteLine("進入Thread");
				for (int i = 0; i < 5; i++) 
				{
					Console.WriteLine("Delay 1 second");
					Task.Delay(1000); //假裝做事
				}
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
