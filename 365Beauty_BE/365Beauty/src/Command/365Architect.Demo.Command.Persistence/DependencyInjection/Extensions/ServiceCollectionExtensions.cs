using _365Beauty.Command.Persistence.DependencyInjection.Options;
using _365Beauty.Command.Persistence.Repositories;
using _365Beauty.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _365Beauty.Command.Persistence.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register infrastructure EF services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Application configuration</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services,
                                                        IConfiguration configuration)
        {
            var connectionStringOptions = new ConnectionStringOptions();
            configuration.GetSection(ConnectionStringOptions.ConnectionStrings).Bind(connectionStringOptions);
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionStringOptions.SqlServer));
            services.RegisterServices();
            return services;
        }

        /// <summary>
        /// Registering infrastructure ef services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IBeautySalonCatalogRepository, BeautySalonCatalogRepository>();
            services.AddScoped<IUserAccountRepository, UserAccoutRepository>();
            return services;
        }
    }
}