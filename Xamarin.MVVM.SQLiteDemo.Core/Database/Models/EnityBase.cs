using System;
using SQLite.Net.Attributes;

namespace Xamarin.MVVM.SQLiteDemo.Core.Database.Models
{
	public class EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int RowId { get; set; }

		public DateTime UpdateDateTime { get; set; }
		public DateTime CreateDateTime { get; set; }

		public EntityBase()
		{
			CreateDateTime = DateTime.Now;
			UpdateDateTime = DateTime.Now;
		}
	}
}
