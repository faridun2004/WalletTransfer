using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Common.Data
{
    public interface IOrderDbContext
    {
        public DbSet<ExchangeWallet> ExchangeWallets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
