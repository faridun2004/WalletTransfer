using Microsoft.EntityFrameworkCore;
using OrderService.Application.Common.Data;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Data
{
    public class OrderDbContext: DbContext, IOrderDbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<ExchangeWallet> ExchangeWallets => Set<ExchangeWallet>();
    }
}
