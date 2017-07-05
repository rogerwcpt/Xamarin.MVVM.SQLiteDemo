namespace Xamarin.MVVM.SQLiteDemo.Core.Database.Models
{
  public class Todo: EntityBase
  {
    public string Name { get; set; }
    public bool Done { get; set; }
  }
}
