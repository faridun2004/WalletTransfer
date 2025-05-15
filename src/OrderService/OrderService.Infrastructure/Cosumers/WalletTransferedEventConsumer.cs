using Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using OrderService.Application.Common.Data;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Cosumers
{
    public class WalletTransferedEventConsumer : IConsumer<WalletTransferedEvent>
    {
        private readonly ILogger<WalletTransferedEventConsumer> _logger;
        private readonly IOrderDbContext _context;

        public WalletTransferedEventConsumer(IOrderDbContext context,
               ILogger<WalletTransferedEventConsumer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<WalletTransferedEvent> context)
        {
            var e = context.Message;
            _logger.LogInformation("Wallet Transfered: {Amount}, {CurrencyFrom}, {CurrencyTo}, {WalletId}, {WalletSentId}",
            context.Message.Amount, context.Message.CurrencyFrom,
            context.Message.CurrencyTo, context.Message.WalletId,
            context.Message.WalletSentId);

            var exchangeWallet = new ExchangeWallet
            {
                Id = Guid.NewGuid(),
                WalletId = e.WalletId,
                WalletSentId = e.WalletSentId,
                Amount = e.Amount,
                CurrencyFrom = e.CurrencyFrom,
                CurrencyTo = e.CurrencyTo

            };

            _context.ExchangeWallets.Add(exchangeWallet);

            await _context.SaveChangesAsync();
        }
    }
}
