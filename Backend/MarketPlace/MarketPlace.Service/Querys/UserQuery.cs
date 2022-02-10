namespace MarketPlace.Service.Querys
{
	public class UserQuery : IQuery<bool>
	{
		public string Token { get; set; }
	}
}
