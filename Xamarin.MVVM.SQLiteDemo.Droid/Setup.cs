using System;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts;
using Xamarin.MVVM.SQLiteDemo.Core.Database;
using Xamarin.MVVM.SQLiteDemo.Core.Platform;
using Xamarin.MVVM.SQLiteDemo.Droid.Platform;

namespace Xamarin.MVVM.SQLiteDemo.Droid
{
    public class Setup : MvxAppCompatSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.LazyConstructAndRegisterSingleton<IDbProvider, SqliteProvider>();
            Mvx.CallbackWhenRegistered<IDatabaseManager>(DatabaseManagerRegistered);

        }

        private void DatabaseManagerRegistered(IDatabaseManager databaseManager)
        {
            databaseManager.InitializeDatabase("1.0");
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
