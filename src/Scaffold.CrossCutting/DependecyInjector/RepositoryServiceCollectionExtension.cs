using Microsoft.Extensions.DependencyInjection;
using Scaffold.Domain.Interfaces;
using Scaffold.Infrastructure.Repositories;

namespace Scaffold.CrossCutting.DependecyInjector
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}