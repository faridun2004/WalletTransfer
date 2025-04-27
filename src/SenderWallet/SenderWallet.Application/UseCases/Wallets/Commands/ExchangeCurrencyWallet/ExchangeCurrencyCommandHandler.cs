using Contracts.Events;
using MediatR;
using SenderWallet.Application.Common.Data;
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
                throw new Exception("Wallet not found");

            if (request.CurrencyFrom == WalletStatus.USD && sender.UsdBalance < request.Amount)
                throw new Exception("Insufficient USD");

            if (request.CurrencyFrom == WalletStatus.TJS && sender.TjsBalance < request.Amount)
                throw new Exception("Insufficient TJS");

            if (request.CurrencyFrom == WalletStatus.USD)
                sender.UsdBalance -= request.Amount;
            else
                sender.TjsBalance -= request.Amount;

            if (request.CurrencyTo == WalletStatus.USD)
                receiver.UsdBalance += request.Amount;
            else
                receiver.TjsBalance += request.Amount;

            await _context.SaveChangesAsync();

            await _eventBus.PublishAsync(new WalletTransferedEvent(
                request.WalletId,
                request.Amount,
                request.CurrencyFrom,
                request.CurrencyTo,
                request.WalletSentId
            ));

            return Guid.NewGuid();
        }
    }
}
