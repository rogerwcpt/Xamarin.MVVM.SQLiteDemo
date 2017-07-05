using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items;

namespace Xamarin.MVVM.SQLiteDemo.iOS.Views.Cells
{
    public partial class TodoItemCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("TodoItemCell");
        public static readonly UINib Nib;

        static TodoItemCell()
        {
            Nib = UINib.FromName("TodoItemCell", NSBundle.MainBundle);
        }

        protected TodoItemCell(IntPtr handle) : base(handle)
        {
			this.DelayBind(() =>
				{
                var set = this.CreateBindingSet<TodoItemCell, TodoItem>();
                set.Bind(NameLabel)
				   .For(x => x.Text)
                   .To(x => x.Name);
                set.Bind(DoneSwitch)
                   .For(x => x.On)
                   .To(x => x.Done);
				set.Apply();
				});
        }
    }
}
