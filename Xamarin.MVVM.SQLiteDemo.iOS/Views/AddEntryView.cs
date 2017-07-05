using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items;

namespace Xamarin.MVVM.SQLiteDemo.iOS.Views
{
    public partial class AddEntryView : MvxViewController<AddEntryViewModel>
    {
        public AddEntryView() : base("AddEntryView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			Title = "TO DO";


			var set = this.CreateBindingSet<AddEntryView, AddEntryViewModel>();
            set.Bind(ItemName).To(vm => vm.ItemName);
            set.Bind(SaveButton).To(vm => vm.SaveCommand);
			set.Apply();
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

