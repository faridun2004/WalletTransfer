using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Infrastrucrure.Data
{
    public class WalletDbContextFactory : IDesignTimeDbContextFactory<WalletDbContext>
    {
        public WalletDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WalletDbContext>();
            var connectionString = "server=localhost;integrated security=True;database=SenderWallet2;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);

            return new WalletDbContext(optionsBuilder.Options);
        }
    }


}
