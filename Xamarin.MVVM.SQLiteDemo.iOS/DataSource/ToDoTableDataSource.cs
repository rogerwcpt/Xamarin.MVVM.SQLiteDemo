using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Xamarin.MVVM.SQLiteDemo.iOS.DataSource
{
    public class ToDoTableDataSource: MvxSimpleTableViewSource
    {
        public ToDoTableDataSource(UITableView tableView): base(tableView, "TodoItemCell", "TodoItemCell")
        {

        }
    }
}
