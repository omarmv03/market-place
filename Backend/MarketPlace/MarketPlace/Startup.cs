using MarketPlace.Api.Helpers;
using MarketPlace.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarketPlace
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			//#region Authentication
			//services.AddAuthentication("MPAuthentication")
			//	.AddScheme<AuthenticationSchemeOptions, MPAuthenticationHandler>("MPAuthentication", null);
			//#endregion
			#region Authentication
			services.AddAuthentication(o => {
				o.DefaultScheme = "MPAuthentication";
			})
			.AddScheme<AuthenticationSchemeOptions, MPAuthenticationHandler>("MPAuthentication", o => { });
			#endregion
			services.AddControllers();
			services.AddServicesDependencies();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(x => x
			.AllowAnyMethod()
			.AllowAnyHeader()
			.SetIsOriginAllowed(origin => true) // allow any origin
			.AllowCredentials()); // allow credentials

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
