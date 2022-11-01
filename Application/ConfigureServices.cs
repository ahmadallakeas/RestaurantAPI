using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mappings;

namespace Application
{
    public static class ConfigureServices
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            ConfigureCors(services);
            ConfigureSerilog();
            ConfigureAutoMapper(services);
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
        }
        public static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                 path: "C:\\Logs\\RestaurantAPILog-.log",
                 outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                 rollingInterval: RollingInterval.Day,
                 restrictedToMinimumLevel: LogEventLevel.Information)
                   .CreateLogger();

        }
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
