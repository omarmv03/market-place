using System;

namespace MarketPlace.Service.Commands
{
	public class LoginCommand
	{
		public LoginCommand(String username, String password)
		{
			this.Username = username;
			this.Password = password;
		}

		public String Username { get; private set; }
		public String Password { get; private set; }
		public bool IsAdmin { get; set; }
		public string Token { get; set; }
	}
}
