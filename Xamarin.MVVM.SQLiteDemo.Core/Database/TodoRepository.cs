using Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Models;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database
{
  public class TodoRepository: Repository<Todo>, ITodoRepository
  {

  }

  public interface ITodoRepository: IRepository<Todo>
  {
  }
}
