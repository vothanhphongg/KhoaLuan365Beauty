using _365Beauty.Query.Domain.Abstractions.Repositories;
using _365Beauty.Query.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Query.Domain.Abstractions.Repositories.Bookings;
using _365Beauty.Query.Domain.Abstractions.Repositories.Localizations;
using _365Beauty.Query.Domain.Abstractions.Repositories.Services;
using _365Beauty.Query.Domain.Abstractions.Repositories.Staffs;
using _365Beauty.Query.Domain.Abstractions.Repositories.Users;
using _365Beauty.Query.Persistence.DependencyInjection.Options;
using _365Beauty.Query.Persistence.Repositories;
using _365Beauty.Query.Persistence.Repositories.BeautySalons;
using _365Beauty.Query.Persistence.Repositories.Bookings;
using _365Beauty.Query.Persistence.Repositories.Localizations;
using _365Beauty.Query.Persistence.Repositories.Services;
using _365Beauty.Query.Persistence.Repositories.Staffs;
using _365Beauty.Query.Persistence.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Users;

namespace _365Beauty.Query.Persistence.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register infrastructure EF services
        /// </summary>
        /// <param name = "services" > Service collection</param>
        /// <param name = "configuration" > Application configuration</param>
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
        /// <param name = "services" > Service collection</param>
        /// <returns>Service collection</returns>
        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
           
            #region beauty salons repo

            services.AddScoped<IBeautySalonCatalogRepository, BeautySalonCatalogRepository>();
            services.AddScoped<IBeautySalonServiceRepository, BeautySalonServiceRepository>();

            #endregion

            #region users repo

            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IUserBookingRepository, UserBookingRepository>();
            services.AddScoped<IUserRatingRepository, UserRatingRepository>();

            #endregion

            #region services repo

            services.AddScoped<IServiceCatalogRepository, ServiceCatalogRepository>();

            #endregion

            #region localizations repo

            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IWardRepository, WardRepository>();

            #endregion

            #region staff repo

            services.AddScoped<IDegreeCatalogRepository, DegreeCatalogRepository>();
            services.AddScoped<IOccupationCatalogRepository, OccupationCatalogRepository>();
            services.AddScoped<ITitleCatalogRepository, TitleCatalogRepository>();
            services.AddScoped<IStaffCatalogRepository, StaffCatalogRepository>();

            #endregion

            #region booking repo

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingTypeRepository, BookingTypeRepository>();
            services.AddScoped<IHistoryTransactionRepository, HistoryTransactionRepository>();
            services.AddScoped<ITimeRepository, TimeRepository>();

            #endregion

            return services;
        }
    }
}