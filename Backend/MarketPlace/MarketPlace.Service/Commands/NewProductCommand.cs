using System;

namespace MarketPlace.Service.Commands
{
	public class NewProductCommand
	{
		public NewProductCommand(String title, String description, Decimal price, String image)
		{
			this.Title = title;
			this.Description = description;
			this.Price = price;
			this.Image = image;
		}

		public String Title { get; private set; }
		public String Description { get; private set; }
		public Decimal Price { get; private set; }
		public String Image { get; set; }
	}
}
