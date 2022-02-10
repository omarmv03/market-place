using MarketPlace.Api.Dto;
using MarketPlace.Domain.Views;
using MarketPlace.Service;
using MarketPlace.Service.Commands;
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
		private readonly ICommandHandler<NewProductCommand> newProductCommandHandler;
		private readonly ICommandHandler<DeleteProductCommand> deleteProductCommandHandler;

		public ProductController(IQueryHandler<AllProductsQuery, List<ProductView>> allProductsQueryHandler,
								ICommandHandler<NewProductCommand> newProductCommandHandler,
								ICommandHandler<DeleteProductCommand> deleteProductCommandHandler)
		{
			if (allProductsQueryHandler is null)
			{
				throw new ArgumentNullException(nameof(allProductsQueryHandler));
			}

			if (newProductCommandHandler is null)
			{
				throw new ArgumentNullException(nameof(newProductCommandHandler));
			}

			if (deleteProductCommandHandler is null)
			{
				throw new ArgumentNullException(nameof(deleteProductCommandHandler));
			}

			this.allProductsQueryHandler = allProductsQueryHandler;
			this.newProductCommandHandler = newProductCommandHandler;
			this.deleteProductCommandHandler = deleteProductCommandHandler;
		}

		[HttpGet]
		public List<ProductView> Products()
		{
			return this.allProductsQueryHandler.Handle(new AllProductsQuery());
		}

		[HttpPost]
		public async Task<IActionResult> NewProduct(NewProductDto newProduct)
		{
			await this.newProductCommandHandler.Handle(new NewProductCommand(newProduct.Titulo, newProduct.Descripcion, Decimal.Parse(newProduct.Precio), newProduct.Imagen));

			return this.Ok(new { Message = "Product successfully created" });
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			try
			{
				await this.deleteProductCommandHandler.Handle(new DeleteProductCommand(id));
			}
			catch (Exception ex)
			{
				return this.Ok(new { Message = ex.Message });
			}
			return this.Ok(new { Message = "Product successfully deleted" });

		}
	}
}
