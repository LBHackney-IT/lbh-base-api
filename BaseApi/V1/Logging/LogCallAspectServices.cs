using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Logging
{
    [ExcludeFromCodeCoverage]
    public static class LogCallAspectServices
    {
        public static IApplicationBuilder UseLogCall(this IApplicationBuilder builder)
        {
            ServiceProvider = builder.ApplicationServices;
            return builder;
        }

        public static IServiceCollection AddLogCallAspect(this IServiceCollection services)
        {
            services.AddTransient<LogCallAspect>();
            return services;
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static LogCallAspectServices() { }

        public static object GetInstance(Type type) => ServiceProvider.GetService(type);
    }
}
