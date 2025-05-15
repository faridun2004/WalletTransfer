using Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Common.DTOs
{
    public class ExchangeWalletDto
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public Guid WalletSentId { get; set; }
        public double Amount { get; set; }
        public WalletStatus CurrencyFrom { get; set; }
        public WalletStatus CurrencyTo { get; set; }
    }
}
