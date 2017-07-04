using MvvmCross.Platform.IoC;

namespace Xamarin.MVVM.SQLiteDemo.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
          CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
          
          CreatableTypes()
            .EndingWith("Manager")
            .AsInterfaces()
            .RegisterAsLazySingleton();          
          
          CreatableTypes()
            .EndingWith("Repository")
            .AsInterfaces()
            .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
