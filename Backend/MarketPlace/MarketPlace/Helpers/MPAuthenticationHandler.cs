using MarketPlace.Service;
using MarketPlace.Service.Querys;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MarketPlace.Api.Helpers
{
	public class MPAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
		private readonly IQueryHandler<UserQuery, bool> userQueryHandler;

		public MPAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryHandler<UserQuery, bool> userQueryHandler)
            : base(options, logger, encoder, clock)
        {
			if (userQueryHandler is null)
			{
				throw new System.ArgumentNullException(nameof(userQueryHandler));
			}

			this.userQueryHandler = userQueryHandler;
		}

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["token"].ToString();
            if (!Request.Headers.ContainsKey("token"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            bool isValidToken = this.userQueryHandler.Handle(new UserQuery { Token = token }); // check token here

            if (!isValidToken)
            {
                return await Task.FromResult(AuthenticateResult.Fail($"Ivalid token : token={token}"));
            }

            var claims = new[] { new Claim("token", token) };
            var identity = new ClaimsIdentity(claims, nameof(MPAuthenticationHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), this.Scheme.Name);
            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
