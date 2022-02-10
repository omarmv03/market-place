namespace MarketPlace.Service.Commands
{
	public class LogoutCommand
	{
		public LogoutCommand(string token)
		{
			this.Token = token;
		}

		public string Token { get; set; }
	}
}
