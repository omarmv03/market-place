using MarketPlace.Api.Dto;
using MarketPlace.Service;
using MarketPlace.Service.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarketPlace.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ICommandHandler<LoginCommand> loginCommandHandler;
		private readonly ICommandHandler<LogoutCommand> logoutCommandHandler;
		private readonly ICommandHandler<RegisterCommand> registerCommandHandler;

		public UserController(ICommandHandler<LoginCommand> loginCommandHandler,
							  ICommandHandler<LogoutCommand> logoutCommandHandler,
							  ICommandHandler<RegisterCommand> registerCommandHandler)
		{
			if (loginCommandHandler is null)
			{
				throw new ArgumentNullException(nameof(loginCommandHandler));
			}

			if (logoutCommandHandler is null)
			{
				throw new ArgumentNullException(nameof(logoutCommandHandler));
			}

			if (registerCommandHandler is null)
			{
				throw new ArgumentNullException(nameof(registerCommandHandler));
			}

			this.loginCommandHandler = loginCommandHandler;
			this.logoutCommandHandler = logoutCommandHandler;
			this.registerCommandHandler = registerCommandHandler;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto userLogin)
		{

			try
			{
				//Encrypt pass
				LoginCommand command = new LoginCommand(userLogin.UserName, userLogin.Password);
				await this.loginCommandHandler.Handle(command);

				return this.Ok(new { Message = "Login success", IsAdmin = command.IsAdmin, Token = command.Token });
			}
			catch (Exception ex)
			{
				return this.Unauthorized(new { Message = ex.Message });
			}
		}

		[Authorize]
		[HttpPost("/logout")]
		public async Task<IActionResult> Logout()
		{
			try
			{
				var token = Request.Headers["token"].ToString();
				await this.logoutCommandHandler.Handle(new LogoutCommand(token));

				return this.Ok(new { Message = "Logout success" });
			}
			catch (Exception)
			{
				return this.Unauthorized();
			}
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto registerDto)
		{
			//Encrypt pass
			await this.registerCommandHandler.Handle(new RegisterCommand(registerDto.UserName, registerDto.Password, registerDto.Name, registerDto.LastName));

			return this.Ok(new { Message = "Register success" });
		}

	}
}
