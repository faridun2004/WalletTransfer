using MediatR;
using SenderWaller.Domain.Entities;

namespace SenderWallet.Application.UseCases.Wallets.Commands.CreateWallet
{
    public record CreateWalletCommand(
        string UserName,
        double USDBalance,
        double TJSBalance
        ) : IRequest<Wallet>;

}
