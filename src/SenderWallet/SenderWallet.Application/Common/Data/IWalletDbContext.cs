using Microsoft.EntityFrameworkCore;
using SenderWaller.Domain.Entities;

namespace SenderWallet.Application.Common.Data
{
    public interface IWalletDbContext
    {
        public DbSet<Wallet> Wallets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
