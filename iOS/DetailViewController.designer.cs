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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton btnMap { get; set; }

		[Outlet]
		UIKit.UIButton btnWeb { get; set; }

		[Outlet]
		UIKit.UIImageView imgPhoto { get; set; }

		[Outlet]
		UIKit.UILabel txtName { get; set; }

		[Outlet]
		UIKit.UILabel txtPhone { get; set; }

		[Outlet]
		UIKit.UIView viewBackground { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (viewBackground != null) {
				viewBackground.Dispose ();
				viewBackground = null;
			}

			if (btnMap != null) {
				btnMap.Dispose ();
				btnMap = null;
			}

			if (btnWeb != null) {
				btnWeb.Dispose ();
				btnWeb = null;
			}

			if (imgPhoto != null) {
				imgPhoto.Dispose ();
				imgPhoto = null;
			}

			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}

			if (txtPhone != null) {
				txtPhone.Dispose ();
				txtPhone = null;
			}
		}
	}
}
