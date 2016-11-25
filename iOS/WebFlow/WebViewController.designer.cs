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
		UIKit.UIButton btnBack { get; set; }

		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UITextField txtURL { get; set; }

		[Outlet]
		UIKit.UIView viewBackground { get; set; }

		[Outlet]
		UIKit.UIWebView viewWeb { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}

			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (txtURL != null) {
				txtURL.Dispose ();
				txtURL = null;
			}

			if (viewBackground != null) {
				viewBackground.Dispose ();
				viewBackground = null;
			}

			if (viewWeb != null) {
				viewWeb.Dispose ();
				viewWeb = null;
			}
		}
	}
}
