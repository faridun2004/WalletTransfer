using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Data
{
    public class NotificationDbContextFactory : IDesignTimeDbContextFactory<NotificationDbContext>
    {
        public NotificationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotificationDbContext>();
            var connectionString = "server=localhost;integrated security=True; database=WalletNotification;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);

            return new NotificationDbContext(optionsBuilder.Options);
        }
    }
}
