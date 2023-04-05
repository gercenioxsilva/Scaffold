using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Scaffold.CrossCutting.Mappers;

namespace Scaffold.CrossCutting.DependecyInjector
{
    public static class AutoMapperServiceCollectionExtension
    {

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperconfig = new MapperConfiguration(mc => 
            {
                mc.AddProfile(new CustomerMapperProfile());
            });

            var mapper = mapperconfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

    }
}
