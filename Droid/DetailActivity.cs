
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Desmond.Droid
{
	[Activity(Label = "DetailActivity")]
	public class DetailActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView(Resource.Layout.detailview);
			var lbName = FindViewById<TextView>(Resource.Id.detailview_lbname);
			var userString = Intent.GetStringExtra("selectedUser");
			// 實際專案這裡要做驗證確認無誤才轉型
			User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(userString);
			lbName.Text = string.Format("I'm {0}", user.Name);

			var btnWeb = FindViewById<Button>(Resource.Id.detailview_btnweb);
			btnWeb.Click += (sender, e) =>
			{
				StartActivity(typeof(WebActivity));
			};
		}
	}
}
