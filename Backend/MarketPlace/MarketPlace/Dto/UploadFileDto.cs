using Microsoft.AspNetCore.Http;
using System;

namespace MarketPlace.Api.Dto
{
	public class UploadFileDto
	{
		public String JsonObject { get; set; }

		public IFormFile File { get; set; }
	}
}
