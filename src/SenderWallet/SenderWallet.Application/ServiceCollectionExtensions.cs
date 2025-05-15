using Microsoft.Extensions.DependencyInjection;
using SenderWallet.Application.Common.Mappers.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application
{
    namespace SenderWallet.Application
    {
        public static class ServiceCollectionExtensions
        {
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
                services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
                services.AddAutoMapper(typeof(WalletMappingProfile));
                return services;
            }
        }
    }
}
