using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Hasher;

namespace Utils
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUtilsConfiguration(this IServiceCollection services)
        {

            //Scoped Services
            services.AddScoped<IPasswordHasher, PasswordHasher >();

            return services;
        }
    }
}
