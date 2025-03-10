using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace _365Beauty.Command.Application.DependencyInjection.Extension
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register application services
        /// </summary>
        /// <param name="services"></param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register mediator
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
            services.AddHttpContextAccessor();
            return services;
        }
    }
}