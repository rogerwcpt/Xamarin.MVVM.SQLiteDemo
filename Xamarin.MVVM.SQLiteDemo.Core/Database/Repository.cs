using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Platform;
using SQLite.Net.Async;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Contracts;
using Xamarin.MVVM.SQLiteDemo.Core.Database.Models;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database
{
	// Generic Repostiorty class that implements most of the required CRUD methods on the database
	public abstract class Repository<T> : IRepository<T> where T : EntityBase, new()
	{
		protected Repository()
		{
		  DataContext = Mvx.Resolve<IDataContext>();
		}

		public async Task<int> InsertOrUpdate(T item)
		{
			if (item.RowId == 0)
			{
				await DataContext.Connection.InsertAsync(item);
			}
			else
			{
				await DataContext.Connection.UpdateAsync(item);
			}

			return item.RowId;
		}

		public async Task<T> GetFirstOrDefault()
		{
			return await DataContext.Connection.Table<T>().FirstOrDefaultAsync();
		}

		public async Task<int> GetCount()
		{
			return await DataContext.Connection.Table<T>().CountAsync();
		}

		public async Task<T> GetById(int id)
		{
			return await DataContext.Connection.FindAsync<T>(x => x.RowId == id);
		}
		public async Task Delete(T item)
		{
			await DataContext.Connection.DeleteAsync(item);
		}

		public async Task DeleteById(int id)
		{
			await DataContext.Connection.DeleteAsync<T>(id);
		}

		public async Task DeleteAll()
		{
			await DataContext.Connection.DeleteAllAsync<T>();
		}

		public async Task<List<T>> GetAll()
		{
			return await DataContext.Connection.Table<T>().ToListAsync();
		}

		public async Task SaveAll(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
					await InsertOrUpdate(item);
			}
		}

	    public AsyncTableQuery<T> Table => DataContext.Connection.Table<T>();

	    /// <summary>
        /// To be used by descendant classes internall only to perform queries va the DataContext
        /// </summary>
        protected IDataContext DataContext { get; }
	}
}
