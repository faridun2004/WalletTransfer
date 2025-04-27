using MediatR;
using SenderWallet.Application.Common.DTOs.Wallet;

namespace SenderWallet.Application.UseCases.Wallets.Queries.GetAll
{
    public record GetWalletsQuery(): IRequest<List<WalletDto>>;
    
}
