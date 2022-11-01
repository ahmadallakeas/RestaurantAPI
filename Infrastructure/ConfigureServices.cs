using Application.Interfaces.IServices;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            ConfigureServiceManager(services);
        }
        public static void ConfigureServiceManager(IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
