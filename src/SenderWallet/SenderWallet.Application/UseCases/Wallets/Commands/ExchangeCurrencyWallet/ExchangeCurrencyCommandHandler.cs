using Contracts.Events;
using MediatR;
using SenderWaller.Domain.Entities;
using SenderWallet.Application.Common.Data;
using SenderWallet.Application.Common.Exceptions.WalletException;
using SenderWallet.Application.Common.Extensions;
using SenderWallet.Application.Common.Interfaces;

namespace SenderWallet.Application.UseCases.Wallets.Commands.ExchangeCurrencyWallet
{
    public class ExchangeCurrencyCommandHandler : IRequestHandler<ExchangeCurrencyCommand, Guid>
    {
        private readonly IWalletDbContext _context;
        private readonly IEventBusPublisher _eventBus;
        public ExchangeCurrencyCommandHandler(IWalletDbContext context, IEventBusPublisher eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }
        public async Task<Guid> Handle(ExchangeCurrencyCommand request, CancellationToken cancellationToken)
        {
            var sender = await _context.Wallets.FindAsync(request.WalletId);
            var receiver = await _context.Wallets.FindAsync(request.WalletSentId);
            if (sender == null || receiver == null)
                throw new WalletNotFoundException("Wallet not found.");
            sender.ValidateSufficientBalance(request.CurrencyFrom, request.Amount);
            sender.PerformCurrencyExchange(receiver, request);
            await _context.SaveChangesAsync();
            await _eventBus.PublishAsync(new WalletTransferedEvent(           
                request.WalletId,
                request.Amount,
                request.CurrencyFrom,
                request.CurrencyTo,
                request.WalletSentId
            ));
            return sender.Id;
        } 
    }
}
