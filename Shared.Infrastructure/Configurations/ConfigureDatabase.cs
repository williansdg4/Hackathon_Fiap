using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.DBContext;

namespace Shared.Infrastructure.Configurations
{
    public static class ConfigureDatabase
    {
        public static void DbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
        }
    }
}
