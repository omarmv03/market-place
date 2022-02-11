using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MarketPlace.Api.Helpers
{
	public static class FormFileExtensions
	{
        public static byte[] GetBytes(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
