using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Xamarin.MVVM.SQLiteDemo.Core.Database;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items;
using MvvmCross.Core.Navigation;

namespace Xamarin.MVVM.SQLiteDemo.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly ITodoRepository _todoRepository;
        readonly IMvxNavigationService navigationService;

        public FirstViewModel(ITodoRepository todoRepository, IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
            _todoRepository = todoRepository;

            Items = new MvxObservableCollection<TodoItem>();
            AddEntry = new MvxAsyncCommand(DoAddEntryAsync);
        }

        private async Task DoAddEntryAsync()
        {
            await navigationService.Navigate<AddEntryViewModel>();

            await PopulateItemsAsync();

        }

        public override async void Appearing()
        {
            base.Appearing();

            await PopulateItemsAsync();
        }

        private async Task PopulateItemsAsync()
        {
            var todoItems = await _todoRepository.GetAll();
            Items.ReplaceRange(todoItems.Select(x => new TodoItem(x.Name, x.Done)), 0, Items.Count());
        }

        public MvxObservableCollection<TodoItem> Items { get; }
        public MvxAsyncCommand AddEntry { get; }

    }
}
