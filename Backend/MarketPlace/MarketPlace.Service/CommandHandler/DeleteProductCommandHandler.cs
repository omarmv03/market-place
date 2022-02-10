using MarketPlace.Infrastructure.DataAccess;
using MarketPlace.Service.Commands;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Service.CommandHandler
{
	public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
	{
		public Task Handle(DeleteProductCommand p)
		{
			var cant = 0;
			using (var ctx = DBContext.GetInstance())
			{

				var queryes = $"SELECT count() cant FROM Products WHERE Id = {p.Id}";

				using (var commands = new SQLiteCommand(queryes, ctx))
				{
					using (var reader = commands.ExecuteReader())
					{
						while (reader.Read())
						{
							cant = String.IsNullOrEmpty(reader["cant"].ToString()) ? 0 : Int32.Parse(reader["cant"].ToString());
						}
					}
				}
			}

			if (cant == 0)
			{
				throw new ArgumentException("Product not exists");
			}

			DeleteProduct(p);
			return Task.CompletedTask;
		}

		private static void DeleteProduct(DeleteProductCommand p)
		{
			using (var ctx = DBContext.GetInstance())
			{
				string query = $"DELETE FROM Products WHERE Id = {p.Id}";
				using (var command = new SQLiteCommand(query, ctx))
				{
					command.ExecuteNonQuery();
				}
			}
		}
	}

}