using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Models;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts
{
	public interface IRepository<T> where T : EntityBase, new()
	{
		/// <summary>
		/// Used for inserts and updates, based on whether the ID is 0 (insert) or > 0 (update)
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Task<int> InsertOrUpdate(T item);
		Task<T> GetById(int id);

		Task<List<T>> GetAll();
		Task SaveAll(IEnumerable<T> items);

		Task Delete(T item);
		Task DeleteById(int id);
		Task DeleteAll();
		Task<T> GetFirstOrDefault();

		Task<int> GetCount();
	    AsyncTableQuery<T> Table { get; }
	}
}
