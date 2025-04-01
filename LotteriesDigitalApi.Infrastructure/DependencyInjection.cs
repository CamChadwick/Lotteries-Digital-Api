using LotteriesDigitalApi.Application.Common.Interfaces.Persistence;
using LotteriesDigitalApi.Application.Common.Interfaces.Services;
using LotteriesDigitalApi.Infrastructure.Presistance;
using LotteriesDigitalApi.Infrastructure.Presistance.Repositories;
using LotteriesDigitalApi.Infrastructure.Services.ThirdPartytTicketSeller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteriesDigitalApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.AddPersistance();
            services.AddSingleton<ITicketProvider, ThirdPartyTicketSeller>();
            services.AddHttpClient();



            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<LotteriesDigitalAPIDbContext>(options =>
            options.UseInMemoryDatabase("LotteriesDb"));
            services.AddScoped<ITicketRepository, TicketRepository>();
        

            return services;
        }
    }
}
