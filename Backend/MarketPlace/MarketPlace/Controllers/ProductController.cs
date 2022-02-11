using MarketPlace.Api.Dto;
using MarketPlace.Domain.Views;
using MarketPlace.Service;
using MarketPlace.Service.Commands;
using MarketPlace.Service.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MarketPlace.Api.Helpers;

namespace MarketPlace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProductController : ControllerBase
	{
		private readonly IQueryHandler<AllProductsQuery, List<ProductView>> allProductsQueryHandler;
		private readonly ICommandHandler<NewProductCommand> newProductCommandHandler;
		private readonly ICommandHandler<DeleteProductCommand> deleteProductCommandHandler;
		private readonly ICommandHandler<AlterProductCommand> alterProductCommandHandler;

		public ProductController(IQueryHandler<AllProductsQuery, List<ProductView>> allProductsQueryHandler,
								ICommandHandler<NewProductCommand> newProductCommandHandler,
								ICommandHandler<DeleteProductCommand> deleteProductCommandHandler,
								ICommandHandler<AlterProductCommand> alterProductCommandHandler)
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

			if (alterProductCommandHandler is null)
			{
				throw new ArgumentNullException(nameof(alterProductCommandHandler));
			}

			this.allProductsQueryHandler = allProductsQueryHandler;
			this.newProductCommandHandler = newProductCommandHandler;
			this.deleteProductCommandHandler = deleteProductCommandHandler;
			this.alterProductCommandHandler = alterProductCommandHandler;
		}

		[HttpGet]
		public List<ProductView> Products()
		{
			return this.allProductsQueryHandler.Handle(new AllProductsQuery());
		}

		[HttpPost]
		public async Task<IActionResult> NewProduct([FromForm] UploadFileDto uploadFileDto)
		{
			try
			{
				NewProductDto product = JsonConvert.DeserializeObject<NewProductDto>(uploadFileDto.JsonObject);
				var fileByte = uploadFileDto.File.GetBytes();
				await this.newProductCommandHandler.Handle(new NewProductCommand(product.Titulo, product.Descripcion, product.Precio, fileByte));

				return this.Ok(new { Message = "Product successfully created" });
			}
			catch (Exception ex)
			{
				return this.BadRequest(new { Message = ex.Message });
			}
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
				return this.BadRequest(new { Message = ex.Message });
			}
			return this.Ok(new { Message = "Product successfully deleted" });

		}

		[HttpPut]
		public async Task<IActionResult> AlterProduct(AlterProductDto alterProductDto)
		{
			try
			{
				await this.alterProductCommandHandler.Handle(new AlterProductCommand(alterProductDto.Id, alterProductDto.Titulo, alterProductDto.Descripcion, alterProductDto.Precio, alterProductDto.Imagen));

				return this.Ok(new { Message = "Product successfully edited" });
			}
			catch (Exception ex)
			{
				return this.BadRequest(new { Message = ex.Message });
			}
		}
	}
}
