using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Desmond.Droid
{
	[Activity(Label = "Desmond", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private EditText _txtAccount;
		private EditText _txtPassword;
		private Button _btnLogin;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource, 類似iOS指派Custom Class
			// View - Controller Binding
			SetContentView(Resource.Layout.loginflow_loginview);

			// View's element binding
			_txtAccount = FindViewById<EditText>(Resource.Id.loginflow_loginview_txtaccount);
			_txtPassword = FindViewById<EditText>(Resource.Id.loginflow_loginview_txtpassword);
			_btnLogin = FindViewById<Button>(Resource.Id.loginflow_loginview_btnlogin);

			_btnLogin.Click += (sender, e) => 
			{
				StartActivity(typeof(MenuActivity));
			};
		}
	}
}

