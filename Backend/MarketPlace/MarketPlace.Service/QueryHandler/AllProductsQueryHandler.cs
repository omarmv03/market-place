﻿using MarketPlace.Domain.Views;
using MarketPlace.Infrastructure.DataAccess;
using MarketPlace.Service.Querys;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MarketPlace.Service.QueryHandler
{
	public class AllProductsQueryHandler : IQueryHandler<AllProductsQuery, List<ProductView>>
    {
        #region Constructors

        public AllProductsQueryHandler()
        {
        }

        #endregion

        #region Methods

        public List<ProductView> Handle(AllProductsQuery query)
        {
            var result = new List<ProductView>();
            using (var ctx = DBContext.GetInstance())
            {

                var queryes = "SELECT * FROM Users";

                using (var command = new SQLiteCommand(queryes, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new ProductView
                            {
                                Id = Convert.ToInt32(reader["id"].ToString())
                            });
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
}
