using _365Beauty.Command.Domain.Abstractions.Repositories;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Command.Domain.Abstractions.Repositories.Prices;
using _365Beauty.Command.Domain.Abstractions.Repositories.Services;
using _365Beauty.Command.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Command.Persistence.DependencyInjection.Options;
using _365Beauty.Command.Persistence.Repositories;
using _365Beauty.Command.Persistence.Repositories.BeautySalons;
using _365Beauty.Command.Persistence.Repositories.Bookings;
using _365Beauty.Command.Persistence.Repositories.Localizations;
using _365Beauty.Command.Persistence.Repositories.Prices;
using _365Beauty.Command.Persistence.Repositories.Services;
using _365Beauty.Command.Persistence.Repositories.Staffs;
using _365Beauty.Command.Persistence.Repositories.Users;
using _365Beauty.Command.Persistence.Settings;
using _365Beauty.Domain.Settings;
using Microsoft.AspNetCore.Identity;
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

            # region service repo

            services.AddScoped<IServiceCatalogRepository, ServiceCatalogRepository>();

            #endregion

            # region localization repo

            services.AddScoped<IWardRepository, WardRepository>();

            #endregion

            #region beauty salon repo

            services.AddScoped<IBeautySalonCatalogRepository, BeautySalonCatalogRepository>();
            services.AddScoped<IBeautySalonServiceRepository, BeautySalonServiceRepository>();

            #endregion

            #region staff repo

            services.AddScoped<IDegreeCatalogRepository, DegreeCatalogRepository>();
            services.AddScoped<IOccupationCatalogRepository, OccupationCatalogRepository>();
            services.AddScoped<ITitleCatalogRepository, TitleCatalogRepository>();
            services.AddScoped<IStaffCatalogRepository, StaffCatalogRepository>();

            #endregion

            #region user repo

            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IUserAccountRoleRepository, UserAccountRoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHasher<UserAccount>, PasswordHasher>();

            #endregion

            #region price repo

            services.AddScoped<IPriceRepository, PriceRepository>();

            #endregion

            #region booking repo

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingTypeRepository, BookingTypeRepository>();
            services.AddScoped<ITimeRepository, TimeRepository>();

            #endregion

            return services;
        }
    }
}