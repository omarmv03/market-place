using MarketPlace.Infrastructure.DataAccess;
using MarketPlace.Service.Commands;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace MarketPlace.Service.CommandHandler
{
	public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
	{

		public RegisterCommandHandler()
		{
		}

		public Task Handle(RegisterCommand r)
		{
			using (var ctx = DBContext.GetInstance())
			{

				string query = "INSERT INTO Users (Name, Lastname, Email, Password, IsAdmin) VALUES (?, ?, ?, ?, ?)";
				using (var command = new SQLiteCommand(query, ctx))
				{
					command.Parameters.Add(new SQLiteParameter("name", r.Name));
					command.Parameters.Add(new SQLiteParameter("lastname", r.LastName));
					command.Parameters.Add(new SQLiteParameter("email", r.Username));
					command.Parameters.Add(new SQLiteParameter("passwrod", r.Password));
					command.Parameters.Add(new SQLiteParameter("isAdmin", "0"));

					command.ExecuteNonQuery();
				}
			}

			return Task.CompletedTask;
		}

	}
}
