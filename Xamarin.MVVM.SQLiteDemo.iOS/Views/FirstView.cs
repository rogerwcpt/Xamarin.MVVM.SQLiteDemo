using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels;

namespace Xamarin.MVVM.SQLiteDemo.iOS.Views
{
    [MvxFromStoryboard]
    public partial class FirstView : MvxViewController
    {
        public FirstView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(Label).To(vm => vm.Hello);
            set.Bind(TextField).To(vm => vm.Hello);
            set.Apply();
        }
    }
}
