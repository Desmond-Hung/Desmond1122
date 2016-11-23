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

		public void UpdateUI(User user) 
		{
			this.lbName.Text = user.Name;
			this.lbDescription.Text = user.Description;
		}
	}
}
