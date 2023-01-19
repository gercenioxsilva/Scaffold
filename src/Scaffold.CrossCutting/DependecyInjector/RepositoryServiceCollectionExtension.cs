using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scaffold.Domain.AggregatesModel.ProductAggregate;
using Scaffold.Infrastructure.Contexts;
using Scaffold.Infrastructure.Repositories.Product;

namespace Scaffold.CrossCutting.DependecyInjector
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddDbContext<ScaffoldContext>();
            services.AddDbContext<ScaffoldContext>(options =>
                options.UseInMemoryDatabase(databaseName: "SQL_ACHE"));

            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}