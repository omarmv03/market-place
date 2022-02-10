using MarketPlace.Domain.Views;
using MarketPlace.Infrastructure.DataAccess;
using MarketPlace.Service.Commands;
using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace MarketPlace.Service.CommandHandler
{
	public class LoginCommandHandler : ICommandHandler<LoginCommand>
	{

		public LoginCommandHandler()
		{
		}

		public Task Handle(LoginCommand command)
		{
			var cant = 0;
			var isAdmin = false;
			using (var ctx = DBContext.GetInstance())
			{

				var queryes = $"SELECT count() cant, isAdmin FROM Users WHERE Email = ? AND Password = ?";

				using (var commands = new SQLiteCommand(queryes, ctx))
				{
					commands.Parameters.Add(new SQLiteParameter("user", command.Username));
					commands.Parameters.Add(new SQLiteParameter("pass", command.Password));
					using (var reader = commands.ExecuteReader())
					{
						while (reader.Read())
						{
							cant = String.IsNullOrEmpty(reader["cant"].ToString()) ? 0 : Int32.Parse(reader["cant"].ToString());
							isAdmin = reader["isAdmin"].ToString() == "False" ? false : true;
						}
					}
				}
			}

			if (cant == 0)
			{
				throw new ArgumentException("User not exists");
			}

			command.IsAdmin = isAdmin;

			var token = Guid.NewGuid().ToString();
			RegisterLogin(command.Username, token);
			command.Token = token;
			return Task.CompletedTask;
		}

		private void RegisterLogin(string username, string token)
		{
			try
			{
				using (var ctx = DBContext.GetInstance())
				{
					string query = $"UPDATE Users SET Token = ? , LastLogin = DateTime('now') WHERE Email = ?";
					using (var command = new SQLiteCommand(query, ctx))
					{
						command.Parameters.Add(new SQLiteParameter("token", token));
						command.Parameters.Add(new SQLiteParameter("email", username));

						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}
