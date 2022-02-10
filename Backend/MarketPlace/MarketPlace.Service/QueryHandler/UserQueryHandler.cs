using MarketPlace.Infrastructure.DataAccess;
using MarketPlace.Service.Querys;
using System.Data.SQLite;

namespace MarketPlace.Service.QueryHandler
{
	public class UserQueryHandler : IQueryHandler<UserQuery, bool>
    {
        #region Constructors

        public UserQueryHandler()
        {
        }

        #endregion

        #region Methods

        public bool Handle(UserQuery query)
        {
            var exists = false;
            using (var ctx = DBContext.GetInstance())
            {
                var queryes = "SELECT count() cant FROM Users WHERE Token = ?";
                using (var command = new SQLiteCommand(queryes, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("token", query.Token));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exists = reader["cant"].ToString() == "0" ? false : true;
                        }
                    }
                }
            }

            return exists;
        }

        #endregion
    }
}
