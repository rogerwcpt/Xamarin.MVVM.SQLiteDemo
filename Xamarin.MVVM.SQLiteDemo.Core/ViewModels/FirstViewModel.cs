using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Xamarin.MVVM.SQLiteDemo.Core.Database;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items;
using MvvmCross.Core.Navigation;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Models;
using MvvmCross.Platform.Platform;

namespace Xamarin.MVVM.SQLiteDemo.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMvxNavigationService navigationService;
        private readonly IMvxTrace _mvxtrace;

        public FirstViewModel(ITodoRepository todoRepository, IMvxNavigationService navigationService, IMvxTrace mvxtrace)
        {
            _mvxtrace = mvxtrace;
            this.navigationService = navigationService;
            _todoRepository = todoRepository;

            Items = new MvxObservableCollection<TodoItem>();
            AddEntry = new MvxAsyncCommand(DoAddEntryAsync);
        }

		public MvxObservableCollection<TodoItem> Items { get; }
		public MvxAsyncCommand AddEntry { get; }
		
		public override async void Appearing()
		{
			base.Appearing();
			
			await PopulateItemsAsync();
		}

		private async Task PopulateItemsAsync()
		{
			var todoItems = await _todoRepository.GetAll();

            Items.Clear();
            Items.AddRange(todoItems.Select(x => new TodoItem(x.RowId, x.Name, x.Done)));

            ObserveItemPropertyChanges();
		}

        private void ObserveItemPropertyChanges()
        {
            foreach(var item in Items)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        private async Task DoAddEntryAsync()
        {
            var todoItem = await navigationService.Navigate<AddEntryViewModel, TodoItem>();

            await _todoRepository.InsertOrUpdate(new Todo() { Name = todoItem.Name, Done = todoItem.Done });

            await PopulateItemsAsync();
        }

        private async void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var itemChanged = (TodoItem)sender;
            // find the item that chagned in the db;

            var todo = await _todoRepository.GetById(itemChanged.Id);

            todo.Name = itemChanged.Name;
            todo.Done = itemChanged.Done;

            await _todoRepository.InsertOrUpdate(todo);
        }
    }
}
