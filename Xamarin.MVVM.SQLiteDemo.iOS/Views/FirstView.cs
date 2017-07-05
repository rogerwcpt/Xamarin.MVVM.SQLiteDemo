using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels;
using Xamarin.MVVM.SQLiteDemo.iOS.DataSource;

namespace Xamarin.MVVM.SQLiteDemo.iOS.Views
{
    [MvxFromStoryboard]
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			this.NavigationItem.RightBarButtonItem = new UIBarButtonItem("Add", UIBarButtonItemStyle.Plain, AddNavBarItem_ClickedAsync);


			var source = new ToDoTableDataSource(TodoTableView);
			this.CreateBinding(source)
				.For(s => s.ItemsSource)
                .To<FirstViewModel>(vm => vm.Items)
				.Apply();
            
			TodoTableView.Source = source;
			TodoTableView.ReloadData();
        }

        private void AddNavBarItem_ClickedAsync(object sender, EventArgs e)
        {
            ViewModel.AddEntry.Execute();
        }
    }
}
