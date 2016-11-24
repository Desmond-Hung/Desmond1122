
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
	[Activity(Label = "MenuActivity")]
	public class MenuActivity : Activity
	{
		private ListView menu_listview;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.menuview);
			// Create your application here

			this.menu_listview = FindViewById<ListView>(Resource.Id.menuview_menulist);
			this.LoadData();
		}

		private void LoadData()
		{
			var list = new List<User>
			{
				new User {Name = @"Aa", Description = @"使用者 甲"},
				new User {Name = @"Bb", Description = @"使用者 乙"},
				new User {Name = @"Cc", Description = @"使用者 丙"},
				new User {Name = @"Dd", Description = @"使用者 丁"}
			};

			RunOnUiThread(() =>
			{
				this.menu_listview.Adapter = new UserListAdapter(this, list);
				this.menu_listview.ItemClick += (sender, args) =>
				{
					User myclass = list[args.Position];
					Console.WriteLine($"{ myclass.Name }");
					Intent nextActivity = new Intent(this, typeof(DetailActivity));
					//建議Extra名: com.thinkpower.xxproject.yyview.selectedUser
					nextActivity.PutExtra("selectedUser", Newtonsoft.Json.JsonConvert.SerializeObject(myclass));
					StartActivity(nextActivity);
				};
			});
		}

		public class UserListAdapter : BaseAdapter<User>
		{
			List<User> Users { get; set; }
			Activity Context { get; set; }

			public UserListAdapter(Activity context, List<User> users) : base()
			{
				this.Users = new List<User>(users);
				Context = context;
			}

			public override long GetItemId(int position)
			{
				return position;
			}

			public override User this[int index]
			{
				get
				{
					return Users[index];
				}
			}

			public override int Count
			{
				get
				{
					return Users.Count;
				}
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				var item = Users[position];

				var view = convertView;
				if (null == view)
				{
					view = Context.LayoutInflater.Inflate(Resource.Layout.menuview_cell, parent, false);
				}

				var lbName = view.FindViewById<TextView>(Resource.Id.menulist_cell_lbName);
				var lbDesc = view.FindViewById<TextView>(Resource.Id.menulist_cell_lbDescription);

				lbName.Text = item.Name;
				lbDesc.Text = item.Description;

				return view;
			}

		}
	}
}
