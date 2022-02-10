using MarketPlace.Infrastructure.DataAccess;
using MarketPlace.Service.Commands;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Service.CommandHandler
{
	public class LogoutCommandHandler : ICommandHandler<LogoutCommand>
	{

		public LogoutCommandHandler()
		{
		}

		public Task Handle(LogoutCommand command)
		{
			try
			{
				using (var ctx = DBContext.GetInstance())
				{
					string query = $"UPDATE Users SET Token = null  WHERE Token = ?";
					using (var commands = new SQLiteCommand(query, ctx))
					{
						commands.Parameters.Add(new SQLiteParameter("token", command.Token));

						commands.ExecuteNonQuery();
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			return Task.CompletedTask;
		}

	}
}
