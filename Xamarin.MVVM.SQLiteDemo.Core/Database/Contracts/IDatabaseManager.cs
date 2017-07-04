using System.Threading.Tasks;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts
{
public interface IDatabaseManager
	{
		Task InitializeDatabase(string appVersion);
	    IDataContext DataContext { get; }
	}
}
