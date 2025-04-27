using Microsoft.EntityFrameworkCore;
using SenderWaller.Domain.Entities;
using SenderWallet.Application.Common.Data;

namespace SenderWallet.Infrastrucrure.Data
{
    public class WalletDbContext : DbContext, IWalletDbContext
    {
        public WalletDbContext(DbContextOptions options): base(options) { }
        public DbSet<Wallet> Wallets => Set<Wallet>();
           
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
