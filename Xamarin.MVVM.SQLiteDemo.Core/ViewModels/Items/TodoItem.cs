using MvvmCross.Core.ViewModels;
namespace Xamarin.MVVM.SQLiteDemo.Core.ViewModels.Items
{
    public class TodoItem: MvxNotifyPropertyChanged
  {
		private bool _done;

        public TodoItem()
        {
        }


        public TodoItem(int id, string name, bool done)
        {
            Id = id;
            Name = name;
          Done = done;
        }

		public int Id { get;  }
        public string Name { get; set; }

        public bool Done
        {
            get { return _done; }
            set { SetProperty(ref _done, value); }
        }
    }
}
