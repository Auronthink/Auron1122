using Android.App;
using Android.Widget;
using Android.OS;

namespace Auron.Droid
{
	[Activity(Label = "Auron", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private EditText _txtAccount;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// iOS Custom Class (interface)
			// View - Controller Binding
			SetContentView(Resource.Layout.loginflow_loginview);

			// View's Element - Controller's UI Control Binding
			_txtAccount = FindViewById<EditText>(Resource.Id.loginflow_loginview_txtaccount);


			var txtPassword = FindViewById<EditText>(Resource.Id.loginflow_loginview_txtpassword);

			var btnlogin = FindViewById<Button>(Resource.Id.loginflow_loginview_btnlogin);
			btnlogin.Click += (sender, e) =>
			{

			};

		}
	}
}

