using SQLite.Net.Interop;

namespace Xamarin.MVVM.SQLiteDemo.Core.Platform
{
	public interface IDbProvider
	{
		ISQLitePlatform SQLitePlatform { get; }
		string DatabasePath { get; }
	}
}
