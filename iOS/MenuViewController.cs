using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIKit;

namespace Desmond.iOS
{
	public partial class MenuViewController : UIViewController
	{
		private Restaurant SelectedItem;

		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "餐廳列表";
			ShowTable();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier == "moveToDetailViewSegue")
			{
				if (segue.DestinationViewController is DetailViewController)
				{
					var destViewController = segue.DestinationViewController as DetailViewController;
					destViewController.SelectedItem = SelectedItem;
				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private void ShowTable()
		{
			List<Restaurant> ItemList = new RestaurantWorker().GetDemoRestaurants(new IOSWorker()); //collect shop data

			// UITableViewSource
			var tableSource = new UserTableSource(ItemList);
			tableUser.Source = tableSource;

			// Table內的點擊事件，預先宣告接收到事件後要做的事
			tableSource.UserSelected += delegate (object sender, UserSelectedEventArgs e)
			{
				//Console.WriteLine(e.SelectedUser.Name);
				this.SelectedItem = e.SelectedItem;
				InvokeOnMainThread(() =>
				{
					PerformSegue("moveToDetailViewSegue", this);
				});
			};
			tableUser.ReloadData(); //預計在main thread呼叫
		}

		public class UserTableSource : UITableViewSource
		{
			// CellView Identifier，輸入storyboard內定義的cell identifier
			const string CellViewIdentifier = @"UserViewCell";
			private List<Restaurant> Items { get; set; }
			public UserTableSource(IEnumerable<Restaurant> users)
			{
				Items = new List<Restaurant>();
				Items.AddRange(users);
			}

			// Model -> Controller -> View

			// Memory
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return (nint)Items.Count;
			}

			// Controller -> View
			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				// 取得一列要顯示的一筆資料
				Restaurant item = Items[indexPath.Row];
				// 利用identifier取得UserViewCell
				var cell = tableView.DequeueReusableCell(CellViewIdentifier) as UserViewCell;
				// 更新View的顯示資料
				cell.UpdateUI(item);
				return cell;
			}

			// View -> Controller
			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);
				Restaurant item = Items[indexPath.Row];
				EventHandler<UserSelectedEventArgs> handle = UserSelected;
				if (null != handle)
				{
					var args = new UserSelectedEventArgs { SelectedItem = item };
					handle(this, args);
				}
			}

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<UserSelectedEventArgs> UserSelected;
   		}
		public class UserSelectedEventArgs : EventArgs
		{
			public Restaurant SelectedItem { get; set; }
		}
	

	}
}

