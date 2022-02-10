using System;

namespace MarketPlace.Service.Commands
{
	public class DeleteProductCommand
	{
		public DeleteProductCommand(Int32 id)
		{
			this.Id = id;
		}

		public Int32 Id { get; private set; }
	}
}
