namespace Xamarin.MVVM.SQLiteDemo.Core.Database.Models
{
  public class Todo: EntityBase
  {
    public Todo(string name, bool done)
    {
      Name = name;
      Done = done;
    }

    public string Name { get; }
    public bool Done { get; }
  }
}
