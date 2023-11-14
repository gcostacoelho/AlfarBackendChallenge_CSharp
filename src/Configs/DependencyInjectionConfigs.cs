using AlfarBackendChallengeV2.src.Data;
using Microsoft.EntityFrameworkCore;

using AlfarBackendChallengeV2.src.Services.CustomerService;
using AlfarBackendChallengeV2.src.Services.Interfaces;

namespace AlfarBackendChallengeV2.src.Configs
{
    public static class DependencyInjectionConfigs
    {
        public static void RegisterDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("DockerConnection")));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}