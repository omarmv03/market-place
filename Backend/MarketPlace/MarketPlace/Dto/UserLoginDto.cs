namespace MarketPlace.Api.Dto
{
	public class UserLoginDto
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool IsAdmin { get; set; }
		public string Token { get; set; }
	}
}
