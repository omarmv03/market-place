using System.Data.SQLite;
using System.IO;

namespace MarketPlace.Infrastructure.DataAccess
{
	public class DBContext
	{
        private const string DBName = "database.sqlite";
        private const string SQLScript = @"..\Util\database.sql";
        private static bool IsDbRecentlyCreated = false;

        public static void Up()
        {
            var asd = Path.GetFullPath(DBName);
            // Crea la base de datos y registra usuario solo una vez
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                IsDbRecentlyCreated = true;
            }

            using (var ctx = GetInstance())
            {
                if (IsDbRecentlyCreated)
				{
					var query = "";
					using (var reader = new StreamReader(Path.GetFullPath(SQLScript)))
					{

						var line = "";
						while ((line = reader.ReadLine()) != null)
						{
							query += line;
						}

						using (var command = new SQLiteCommand(query, ctx))
						{
							command.ExecuteNonQuery();
						}
					}

					InitialUsers(ctx);
					InitialProduct(ctx);
				}
			}
        }

		private static void InitialProduct(SQLiteConnection ctx)
		{
			string query = "INSERT INTO Products (Title, Description, Price, Image) VALUES (?, ?, ?, ?)";
			using (var command = new SQLiteCommand(query, ctx))
			{
				command.Parameters.Add(new SQLiteParameter("title", "Teclado Gammer"));
				command.Parameters.Add(new SQLiteParameter("description", "Teclado Gammer con 6 meses garantia"));
				command.Parameters.Add(new SQLiteParameter("price", "5000"));
				command.Parameters.Add(new SQLiteParameter("image", "https://http2.mlstatic.com/D_NQ_NP_929016-MLA45169314172_032021-O.webp"));

				command.ExecuteNonQuery();
			}
		}

		private static void InitialUsers(SQLiteConnection ctx)
		{
			string query = "INSERT INTO Users (Name, Lastname, Email, Password, IsAdmin) VALUES (?, ?, ?, ?, ?)";
			using (var command = new SQLiteCommand(query, ctx))
			{
				command.Parameters.Add(new SQLiteParameter("name", "guest"));
				command.Parameters.Add(new SQLiteParameter("lastname", "guest"));
				command.Parameters.Add(new SQLiteParameter("email", "guest@guest.com"));
				command.Parameters.Add(new SQLiteParameter("passwrod", "guest"));
				command.Parameters.Add(new SQLiteParameter("isAdmin", "0"));

				command.ExecuteNonQuery();
			}
			using (var command = new SQLiteCommand(query, ctx))
			{
				command.Parameters.Add(new SQLiteParameter("name", "admin"));
				command.Parameters.Add(new SQLiteParameter("lastname", "admin"));
				command.Parameters.Add(new SQLiteParameter("email", "admin@admin.com"));
				command.Parameters.Add(new SQLiteParameter("passwrod", "admin"));
				command.Parameters.Add(new SQLiteParameter("isAdmin", "1"));

				command.ExecuteNonQuery();
			}
		}

		public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", DBName)
            );

            db.Open();

            return db;
        }
    }
}
