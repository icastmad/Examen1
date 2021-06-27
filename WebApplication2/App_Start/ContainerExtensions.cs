using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;

namespace WebApplication2
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<ITitulosService, TitulosService>();
            services.AddTransient<IPuestosService, PuestosService>();
            services.AddTransient<IDepartamentosService, DepartamentosService>();

            return services;
        }
    }
}
