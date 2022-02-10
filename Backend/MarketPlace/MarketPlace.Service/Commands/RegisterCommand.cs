namespace MarketPlace.Service.Commands
{
	public class RegisterCommand 
	{
		public RegisterCommand(string username, string password, string name, string lastname)
		{
			this.LastName = lastname;
			this.Name = name;
			this.Password = password;
			this.Username = username;
		}
		public string Username { get; private set; }
		public string Password { get; private set; }
		public string Name { get; private set; }
		public string LastName { get; private set; }
	}
}
