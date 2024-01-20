using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.AccountServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {

            //Scoped Services
            services.AddScoped<IRegisterService, RegisterService>();


            return services;
        }
    }
}
