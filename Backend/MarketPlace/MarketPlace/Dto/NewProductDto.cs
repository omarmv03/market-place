using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Api.Dto
{
	public class NewProductDto
	{
		[Required(ErrorMessage = "Descripcion requerida")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "Imagen requerida")]
		public string Imagen { get; set; }
		[Required(ErrorMessage = "Titulo requerido")]
		public string Titulo { get; set; }
		[Required(ErrorMessage = "Precio requerido")]
		public int Precio { get; set; }
	}
}
