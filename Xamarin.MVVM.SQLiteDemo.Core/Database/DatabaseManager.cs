using System.Threading.Tasks;
using MvvmCross.Plugins.File;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Models;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database
{
	public class DatabaseManager: IDatabaseManager
	{
	  private readonly IMvxFileStore _mvxfileStore;
	  private readonly IDataContext _dataContext;
	  private readonly IVersionInfoRepository _versionInfoRepository;

	  public DatabaseManager(
			IMvxFileStore mvxfileStore,
			IDataContext dataContext,
			IVersionInfoRepository versionInfoRepository)
		{
			_dataContext = dataContext;
		  _versionInfoRepository = versionInfoRepository;
		  _mvxfileStore = mvxfileStore;
		}

	    public IDataContext DataContext => _dataContext;

	    public async Task InitializeDatabase(string appVersion)
		{
			if (_mvxfileStore.Exists(_dataContext.DatabasePath))
			{
				var isCurrentVersion  = await _versionInfoRepository.VersionDataExists(appVersion);
				if (isCurrentVersion)
				{
					return;
				}
				else
				{
					DropDatabase();
				}

			}

		    await CreateTables();

			await _versionInfoRepository.SetVersionData(appVersion);
		}

	    protected virtual async Task CreateTables()
	    {
	        await _dataContext.Connection.CreateTableAsync<VersionInfo>();
	        await _dataContext.Connection.CreateTableAsync<Todo>();
	    }

        void DropDatabase()
		{
			_dataContext.CloseConnection();
			_mvxfileStore.DeleteFile(_dataContext.DatabasePath);
		}
}
}
