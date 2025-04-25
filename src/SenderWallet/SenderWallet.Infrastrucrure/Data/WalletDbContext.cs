using Microsoft.EntityFrameworkCore;
using SenderWaller.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SenderWallet.Infrastrucrure.Data
{
    public class WalletDbContext : DbContext
    {
        public DbSet<Wallet> Wallets => Set<Wallet>();
        public DbSet<WalletTransaction> WalletTransactions => Set<WalletTransaction>();

        public WalletDbContext(DbContextOptions<WalletDbContext> options)
            : base(options) { }
    }

}
