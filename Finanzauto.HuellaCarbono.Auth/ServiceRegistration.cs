using Finanzauto.HuellaCarbono.App.Contracts.Auth;
using Finanzauto.HuellaCarbono.Auth.Handlers;
using Finanzauto.HuellaCarbono.Auth.Models;
using Finanzauto.HuellaCarbono.Auth.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Auth
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IClientsService, ClientsService>();
            services.AddScoped<ICacheService, CacheService>();
            services.Configure<ApikeyClientsSettings>(configuration.GetSection("ApikeyClientsSettings"));
            services.AddMemoryCache();

            return services;
        }
    }
}
