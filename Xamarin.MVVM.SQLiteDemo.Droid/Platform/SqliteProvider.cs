using System;
using System.IO;
using MvvmCross.Platform.Platform;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.MVVM.SQLiteDemo.Core.Platform;

namespace Xamarin.MVVM.SQLiteDemo.Droid.Platform
{
	public class SqliteProvider : IDbProvider
	{
	  public SqliteProvider(IMvxTrace mvxTrace)
		{
		  DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
			SQLitePlatform = new SQLitePlatformAndroidN();

#if DEBUG
			mvxTrace.Trace(MvxTraceLevel.Diagnostic, this.GetType().Name, $"DATABASEPATH :[{DatabasePath}]");
#endif

		}

		public ISQLitePlatform SQLitePlatform { get; private set; }
		public string DatabasePath { get; private set; }
	}
}
