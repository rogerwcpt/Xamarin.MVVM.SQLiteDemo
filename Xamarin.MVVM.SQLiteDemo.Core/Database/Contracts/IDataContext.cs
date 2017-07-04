namespace Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts
{
	public interface IDataContext
	{
		string DatabasePath { get; }

		SQLiteAsyncConnection Connection { get; }

		void CloseConnection();
	}
}
