using System;
using System.Collections.Generic;
using UIKit;

namespace Desmond.iOS
{
	public partial class MenuViewController : UIViewController
	{
		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			ShowTable();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public void ShowTable()
		{
			// 範例資料
			var list = new List<User>
			{
				new User {Name = @"Aa", Description = @"使用者 甲"},
				new User {Name = @"Bb", Description = @"使用者 乙"},
				new User {Name = @"Cc", Description = @"使用者 丙"},
				new User {Name = @"Dd", Description = @"使用者 丁"}
			};

			// UITableViewSource
			var tableSource = new UserTableSource(list);
			tableUser.Source = tableSource;

			// Table內的點擊事件，預先宣告接收到事件後要做的事
			tableSource.UserSelected += delegate (object sender, UserSelectedEventArgs e)
			{
				Console.WriteLine(e.SelectedUser.Name);
			};
			tableUser.ReloadData();
		}

		public class UserTableSource : UITableViewSource
		{
			// CellView Identifier，輸入storyboard內定義的cell identifier
			const string CellViewIdentifier = @"UserViewCell";
			private List<User> Users { get; set; }
			public UserTableSource(IEnumerable<User> users)
			{
				Users = new List<User>();
				Users.AddRange(users);
			}

			// Model -> Controller -> View

			// Memory
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return (nint)Users.Count;
			}

			// Controller -> View
			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				// 取得一列要顯示的一筆資料
				User myClass = Users[indexPath.Row];
				// 利用identifier取得UserViewCell
				var cell = tableView.DequeueReusableCell(CellViewIdentifier) as UserViewCell;
				// 更新View的顯示資料
				cell.UpdateUI(myClass);
				return cell;
			}

			// View -> Controller
			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);
				User user = Users[indexPath.Row];
				EventHandler<UserSelectedEventArgs> handle = UserSelected;
				if (null != handle)
				{
					var args = new UserSelectedEventArgs { SelectedUser = user };
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
			public User SelectedUser { get; set; }
		}
	}
}

