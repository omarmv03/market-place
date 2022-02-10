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
			return services;
		}

		public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
		{
			services.AddTransient<ICommandHandler<NewProductCommand>, NewProductCommandHandler>();
			services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
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
