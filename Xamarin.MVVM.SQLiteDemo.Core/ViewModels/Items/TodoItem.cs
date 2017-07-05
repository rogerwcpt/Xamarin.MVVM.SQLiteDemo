namespace Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items
{
  public class TodoItem
  {
	    public TodoItem(string name, bool done)
	    {
	      Name = name;
	      Done = done;
	    }

        public string Name { get; set; }
        public bool Done { get; set; }
  }
}
