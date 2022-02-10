using MarketPlace.Infrastructure.DataAccess;
using MarketPlace.Service.Commands;
using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace MarketPlace.Service.CommandHandler
{
	public class AlterProductCommandHandler : ICommandHandler<AlterProductCommand>
    {

        public AlterProductCommandHandler()
        {
        }

        public Task Handle(AlterProductCommand command)
        {
            var cant = 0;
            using (var ctx = DBContext.GetInstance())
            {

                var queryes = $"SELECT count() cant FROM Products WHERE Id = {command.Id}";

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

            UpdateProduct(command);

            return Task.CompletedTask;
        }

        private void UpdateProduct(AlterProductCommand p)
        {
            using (var ctx = DBContext.GetInstance())
            {
                string query = $"UPDATE Products SET Title = ?, Description = ?, Price = ?, Image = ? WHERE ID = {p.Id}";
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
