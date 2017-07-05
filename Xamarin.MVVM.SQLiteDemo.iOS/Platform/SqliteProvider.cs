using System;
using System.IO;
using MvvmCross.Platform.Platform;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.MVVM.SQLiteDemo.Core.Platform;

namespace Aliens.MegaU.iOS.Platform
{
	public class SqliteProvider: IDbProvider
	{
		readonly IMvxTrace _mvxTrace;

		public SqliteProvider(IMvxTrace mvxTrace)
		{
			_mvxTrace = mvxTrace;
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			var libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			DatabasePath = Path.Combine(libraryPath, "demo.db");

#if DEBUG
			_mvxTrace.Trace(MvxTraceLevel.Diagnostic, this.GetType().Name, string.Format("DATABASEPATH :[{0}]", DatabasePath));
#endif

			SQLitePlatform = new SQLitePlatformIOS();

		}

		public ISQLitePlatform SQLitePlatform { get; private set; }
		public string DatabasePath { get; private set; }

	
	}
}
