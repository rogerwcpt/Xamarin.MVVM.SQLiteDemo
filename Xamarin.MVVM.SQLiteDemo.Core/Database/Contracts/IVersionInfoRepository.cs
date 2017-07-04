using System.Threading.Tasks;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts
{
	public interface IVersionInfoRepository
	{
		Task<bool> VersionDataExists(string versionData);
		Task SetVersionData(string versionData);
	}
}
