
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

namespace Xamarin.MVVM.SQLiteDemo.Droid.Views
{
    [Activity(Label = "AddEntryView")]
    public class AddEntryView : BaseView
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override int LayoutResource => Resource.Layout.AddEntry;

	}
}
