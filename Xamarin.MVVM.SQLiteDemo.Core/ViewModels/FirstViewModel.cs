using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Xamarin.MVVM.SQLiteDemo.Core.Database;
using Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items;

namespace Xamarin.MVVM.SQLiteDemo.Core.ViewModels
{
    public class FirstViewModel: MvxViewModel
    {
      private readonly ITodoRepository _todoRepository;

      public FirstViewModel(ITodoRepository todoRepository)
      {
        _todoRepository = todoRepository;
        
        Items = new MvxObservableCollection<TodoItem>();
      }

      public override async Task Initialize()
      {
        await base.Initialize();

        var todoItems = await _todoRepository.GetAll();
        Items.AddRange(todoItems.Select(x => new TodoItem(x.Name, x.Done)));
      }

      public MvxObservableCollection<TodoItem> Items { get; }
    }
}
