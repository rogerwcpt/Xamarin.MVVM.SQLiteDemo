using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Xamarin.MVVM.SQLiteDemo.Core.Database;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Models;
namespace Xamarin.MVVM.SQLiteDemo.Core.ViewModels
{
    public class AddEntryViewModel: MvxViewModel
    {
        private readonly ITodoRepository _todoRepo;

        public AddEntryViewModel(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
            SaveCommand = new MvxAsyncCommand(DoSaveCommandAsync);
        }

		public string ItemName { get; set; }
		public MvxAsyncCommand SaveCommand { get; }


        private async Task DoSaveCommandAsync()
        {
            var todo = new Todo()
            {
                Name = ItemName
            };

            await _todoRepo.InsertOrUpdate(todo);

            Close(this);
        }
    }
}
