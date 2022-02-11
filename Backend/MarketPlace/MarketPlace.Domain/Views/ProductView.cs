namespace MarketPlace.Domain.Views
{
	public class ProductView
	{
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public byte[] Imagen { get; set; }
		public string Titulo { get; set; }
		public decimal Precio { get; set; }
	}
}
