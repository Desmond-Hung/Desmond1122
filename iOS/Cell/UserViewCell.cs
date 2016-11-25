using System;

using Foundation;
using UIKit;

namespace Desmond.iOS
{
	public partial class UserViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("UserViewCell");
		public static readonly UINib Nib;

		static UserViewCell()
		{
			Nib = UINib.FromName("UserViewCell", NSBundle.MainBundle);
		}

		protected UserViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUI(Restaurant res) 
		{
			this.lbName.Text = res.Name;
			this.lbDescription.Text = res.Address;
			this.imgPhoto.Image = UIImage.FromFile("Images/" + res.Image);
		}
	}
}
