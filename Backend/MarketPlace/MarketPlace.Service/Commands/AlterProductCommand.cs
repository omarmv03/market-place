using System;

namespace MarketPlace.Service.Commands
{
	public class AlterProductCommand
	{
		public AlterProductCommand(int id, String title, String description, Decimal price, String image)
		{
			this.Id = id;
			this.Title = title;
			this.Description = description;
			this.Price = price;
			this.Image = image;
		}

		public String Title { get; private set; }
		public String Description { get; private set; }
		public Decimal Price { get; private set; }
		public String Image { get; set; }
		public int Id { get; set; }
	}
}
