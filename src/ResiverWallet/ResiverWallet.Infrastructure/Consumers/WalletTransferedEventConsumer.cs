using Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using NotificationService.Application.Common.Data;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Consumers
{
    public class WalletTransferedEventConsumer : IConsumer<WalletTransferedEvent>
    {
        private readonly ILogger<WalletTransferedEventConsumer> _logger;
        private readonly INotificationDbContext _context;

        public WalletTransferedEventConsumer(INotificationDbContext context, 
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

            string mesage=($"Перевод: {e.Amount} {e.CurrencyFrom} → {e.CurrencyTo} от {e.WalletId} к {e.WalletSentId}");
            
            var transferNotification = new Notification
            {
                WalletId = e.WalletId,
                WalletSentId = e.WalletSentId,
                Amount = e.Amount,
                CurrencyFrom = e.CurrencyFrom,
                CurrencyTo = e.CurrencyTo,
                TransferDate = DateTime.UtcNow,
                Message=mesage
                
            };

            _context.Notifications.Add(transferNotification);

            await _context.SaveChangesAsync();
        }
    }

}
