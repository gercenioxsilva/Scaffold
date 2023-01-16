using Microsoft.Extensions.DependencyInjection;
using Scaffold.CrossCutting.Logging;

namespace Scaffold.CrossCutting.DependecyInjector
{
    public static class LoggingServiceCollectionExtension
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            var logger = LoggerManager.CreateLogger();
            services.AddSingleton(logger);
            return services;
        }
    }
}
