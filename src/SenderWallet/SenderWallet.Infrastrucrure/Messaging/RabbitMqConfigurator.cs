using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Infrastrucrure.Messaging
{
    public static class RabbitMqConfigurator
    {
        public static void Configure(IRabbitMqBusFactoryConfigurator cfg, IConfiguration config)
        {
            var host = config["RabbitMq:Host"]
                       ?? throw new InvalidOperationException("RabbitMq:Host not set");
            var username = config["RabbitMq:Username"]
                           ?? throw new InvalidOperationException("RabbitMq:Username not set");
            var password = config["RabbitMq:Password"]
                           ?? throw new InvalidOperationException("RabbitMq:Password not set");

            cfg.Host(new Uri(host), h =>
            {
                h.Username(username);
                h.Password(password);
            });
        }
    }

}
