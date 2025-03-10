using _365Beauty.Contract.DependencyInjection.Options;
using Commerce.Command.Contract.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _365Beauty.Contract.DependencyInjection.Extensions
{
    public static class VnPayServiceServiceCollectionExtensions
    {
        public static IServiceCollection AddVNPay(this IServiceCollection services, IConfiguration configuration)
        {
            var vnPayOption = new VNPayOption();
            configuration.GetSection("VNPay").Bind(vnPayOption);

            services.Configure<VNPayOption>(configuration.GetSection("VNPay"));

            services.AddScoped<IVnpay>(provider =>
            {
                var vnpay = new Vnpay();
                vnpay.Initialize(
                    vnPayOption.TmnCode,
                    vnPayOption.HashSecret,
                    vnPayOption.BaseUrl,
                    vnPayOption.CallbackUrl
                );
                return vnpay;
            });

            return services;
        }
    }
}
