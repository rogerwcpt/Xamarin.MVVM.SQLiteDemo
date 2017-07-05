using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts;
using Xamarin.MVVM.SQLiteDemo.Core.Database;

namespace Xamarin.MVVM.SQLiteDemo.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.LazyConstructAndRegisterSingleton<IDataContext, DataContext>();
			Mvx.LazyConstructAndRegisterSingleton<ITodoRepository, TodoRepository>();
            Mvx.LazyConstructAndRegisterSingleton<IVersionInfoRepository, VersionInfoRepository>();
			Mvx.LazyConstructAndRegisterSingleton<IDatabaseManager, DatabaseManager>();

			RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
