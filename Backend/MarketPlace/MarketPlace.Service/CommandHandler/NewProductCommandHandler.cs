using MarketPlace.Service.Commands;
using System;
using System.Threading.Tasks;
using MarketPlace.Infrastructure.DataAccess;
using System.Data.SQLite;

namespace MarketPlace.Service.CommandHandler
{
	public class NewProductCommandHandler : ICommandHandler<NewProductCommand>
    {

        public NewProductCommandHandler()
        {
        }

        public Task Handle(NewProductCommand command)
        {
            var cant = 0;
            using (var ctx = DBContext.GetInstance())
            {

                var queryes = $"SELECT count() cant FROM Products WHERE Title = '{command.Title}'";

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

            if (cant > 0)
            {
                throw new ArgumentException("Product exists");
            }

            InsertProduct(command);

            return Task.CompletedTask;
        }

        private void InsertProduct(NewProductCommand p)
        {
            using (var ctx = DBContext.GetInstance())
            {
                string query = "INSERT INTO Products (Title, Description, Price, Image) VALUES (?, ?, ?, ?)";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("title", p.Title));
                    command.Parameters.Add(new SQLiteParameter("description", p.Description));
                    command.Parameters.Add(new SQLiteParameter("price", p.Price));
                    command.Parameters.Add(new SQLiteParameter("image", p.Image));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
