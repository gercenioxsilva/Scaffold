using Microsoft.Extensions.DependencyInjection;

namespace Scaffold.CrossCutting.DependecyInjector
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services) 
        {
            return services;
        }
    }
}
