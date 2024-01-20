using DatabaseIntegration.Database;
using DatabaseIntegration.Interfaces;
using DatabaseIntegration.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseIntegration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //dbContext config and scope
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDatabase"))
                       .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information));

            //Repositories Scope
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
