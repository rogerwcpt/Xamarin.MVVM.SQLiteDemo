using MvvmCross.Core.ViewModels;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items;
namespace Xamarin.MVVM.SQLiteDemo.Core.ViewModels
{
    public class AddEntryViewModel: MvxViewModelResult<TodoItem>
    {
        public AddEntryViewModel()
        {
            SaveCommand = new MvxCommand(DoSaveCommand);
        }

		public string ItemName { get; set; }
		public MvxCommand SaveCommand { get; }

        private void DoSaveCommand()
        {
            var todoItem = new TodoItem(0, ItemName, false);
            Close(todoItem);
        }
    }
}
