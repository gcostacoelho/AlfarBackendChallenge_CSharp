using Microsoft.EntityFrameworkCore;

using AlfarBackendChallengeV2.src.Data;
using AlfarBackendChallengeV2.src.Services.Interfaces;
using AlfarBackendChallengeV2.src.Services.CustomerService;
using AlfarBackendChallengeV2.src.Services.MailKitService;
using AlfarBackendChallengeV2.src.Models;

namespace AlfarBackendChallengeV2.src.Configs
{
    public static class DependencyInjectionConfigs
    {
        public static void RegisterDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DockerConnection")));
        }

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IMailKitService, MailKitService>();

            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}