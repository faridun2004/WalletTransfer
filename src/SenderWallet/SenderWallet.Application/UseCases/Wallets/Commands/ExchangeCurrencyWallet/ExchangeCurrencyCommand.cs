using Contracts.Events;
using MediatR;

namespace SenderWallet.Application.UseCases.Wallets.Commands.ExchangeCurrencyWallet
{
    public record ExchangeCurrencyCommand(
        Guid WalletId,
        double Amount,
        WalletStatus CurrencyFrom,
        WalletStatus CurrencyTo,
        Guid WalletSentId
    ) : IRequest<Guid>;
}
