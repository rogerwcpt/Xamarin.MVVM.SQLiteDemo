using System;
using SQLite.Net;
using SQLite.Net.Async;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts;
using Xamarin.MVVM.SQLiteDemo.Core.Platform;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database
{
	/// <summary>
	/// Serves up the database connection using the databas provider as implemented by the respecive platforms
	/// </summary>
	public class DataContext : IDataContext
	{
		private SQLiteConnectionWithLock _connection;
		private readonly SQLiteConnectionString _connectionString;
		private Func<SQLiteConnectionWithLock> _connectionFactory;


		public DataContext(IDbProvider dbProvider)
		{
			var sqlitePlatform = dbProvider.SQLitePlatform;
			DatabasePath = dbProvider.DatabasePath;
			_connectionString = new SQLiteConnectionString(DatabasePath, true);

			_connectionFactory = new Func<SQLiteConnectionWithLock>(() =>
			 {
				 if (_connection == null)
				 {
					_connection = new SQLiteConnectionWithLock(sqlitePlatform, _connectionString);
				 }
				 return _connection;
			 });
		}

		public string DatabasePath { get; private set; }
		public SQLiteAsyncConnection Connection => new SQLiteAsyncConnection(_connectionFactory);

		public void CloseConnection()
		{
			if (_connection != null)
			{
				_connection.Close();
				_connection.Dispose();
				_connection = null;

				// Must be called as the disposal of the connection is not released until the GC runs.
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}
	}
}
