using Microsoft.EntityFrameworkCore;
using SenderWaller.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application.Data
{
    public interface IWalletDbContext
    {
        public DbSet<Wallet> Wallets { get; }
        public DbSet<WalletTransaction> WalletTransactions { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
