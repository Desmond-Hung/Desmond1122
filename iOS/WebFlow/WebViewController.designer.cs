// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Desmond.iOS
{
	[Register ("WebViewController")]
	partial class WebViewController
	{
		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UITextField txtURL { get; set; }

		[Outlet]
		UIKit.UIWebView viewWeb { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (viewWeb != null) {
				viewWeb.Dispose ();
				viewWeb = null;
			}

			if (txtURL != null) {
				txtURL.Dispose ();
				txtURL = null;
			}

			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}
		}
	}
}
