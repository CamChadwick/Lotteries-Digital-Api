using LotteriesDigitalApi.API.Common.Errors;
using LotteriesDigitalApi.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LotteriesDigitalApi.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, LotteriesDigitalAPIProblemDetailsFactory>();
            services.AddMappings();


            return services;
        }
    }
}