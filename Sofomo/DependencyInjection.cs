using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sofomo.Data;
using Sofomo.Data.IRepositories;
using Sofomo.Extension;
using Sofomo.IpStack;
using Sofomo.Logic;
using Sofomo.Models;

namespace Sofomo
{
    public class DependencyInjection
    {
        public static IServiceCollection Di(IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ILogic, Logic.Logic>();
            services.AddScoped<IDbAlive, DBAlive>();
            services.AddScoped<IIpStackClient, IpStackClient>();
            return services;
        }
    }
}
