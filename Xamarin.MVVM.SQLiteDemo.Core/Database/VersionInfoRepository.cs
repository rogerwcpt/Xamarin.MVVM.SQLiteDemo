using System.Threading.Tasks;
using MvvmCross.Platform.Platform;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Models;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database
{
	public class VersionInfoRepository : Repository<VersionInfo>, IVersionInfoRepository
	{
		readonly IMvxTrace _mvxTrace;

		public VersionInfoRepository(IMvxTrace mvxTrace) : base()
		{
			_mvxTrace = mvxTrace;
		}

		public async Task<bool> VersionDataExists(string versionData)
		{
				var versionRow = await DataContext.Connection
												  .Table<VersionInfo>()
												  .Where(x => x.VersionData == versionData)
												  .FirstOrDefaultAsync();
#if DEBUG
				if (versionRow != null)
				{
					_mvxTrace.Trace(MvxTraceLevel.Diagnostic, this.GetType().Name, "Database Version: " + versionRow.VersionData);
				}
#endif
				return versionRow != null;
		}

		public async Task SetVersionData(string versionData)
		{
				await DeleteAll();
				await InsertOrUpdate(new VersionInfo { VersionData = versionData });
		}
	}
}
