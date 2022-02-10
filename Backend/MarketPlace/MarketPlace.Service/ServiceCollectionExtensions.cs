using MarketPlace.Domain.Views;
using MarketPlace.Service.CommandHandler;
using MarketPlace.Service.Commands;
using MarketPlace.Service.QueryHandler;
using MarketPlace.Service.Querys;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MarketPlace.Service
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
		{
			services.AddTransient<IQueryHandler<AllProductsQuery, List<ProductView>>, AllProductsQueryHandler>();
			services.AddTransient<IQueryHandler<UserQuery, bool>, UserQueryHandler>();
			return services;
		}

		public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
		{
			services.AddTransient<ICommandHandler<NewProductCommand>, NewProductCommandHandler>();
			services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
			services.AddTransient<ICommandHandler<AlterProductCommand>, AlterProductCommandHandler>();
			services.AddTransient<ICommandHandler<LoginCommand>, LoginCommandHandler>();
			services.AddTransient<ICommandHandler<LogoutCommand>, LogoutCommandHandler>();
			services.AddTransient<ICommandHandler<RegisterCommand>, RegisterCommandHandler>();
			return services;
		}

		public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
		{
			services.AddQueryHandlers();
			services.AddCommandHandlers();
			return services;
		}
	}
}
