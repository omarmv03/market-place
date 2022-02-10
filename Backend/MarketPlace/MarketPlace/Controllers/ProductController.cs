using MarketPlace.Domain.Views;
using MarketPlace.Service;
using MarketPlace.Service.Querys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IQueryHandler<AllProductsQuery, List<ProductView>> allProductsQueryHandler;

		public ProductController(IQueryHandler<AllProductsQuery, List<ProductView>> allProductsQueryHandler)
		{
			if (allProductsQueryHandler is null)
			{
				throw new ArgumentNullException(nameof(allProductsQueryHandler));
			}

			this.allProductsQueryHandler = allProductsQueryHandler;
		}

		[HttpGet]
		public List<ProductView> Products()
		{
			return this.allProductsQueryHandler.Handle(new AllProductsQuery());
		}
	}
}
