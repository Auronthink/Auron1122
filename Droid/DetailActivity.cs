
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

namespace Auron.Droid
{
	[Activity(Label = "DetailActivity")]
	public class DetailActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView(Resource.Layout.detailview);

			var lbName = FindViewById<TextView>(Resource.Id.detailview_lbName);

			var userString = Intent.GetStringExtra("selectedUser");
			Food user = Newtonsoft.Json.JsonConvert.DeserializeObject<Food>(userString);

			lbName.Text = user.Name;


			var btnWeb = FindViewById<Button>(Resource.Id.btnWeb);

			btnWeb.Click += (sender, e) => {
				Intent nextActivity = new Intent(this, typeof(WebActivity));

				StartActivity(nextActivity);
			};
		}
	}
}
