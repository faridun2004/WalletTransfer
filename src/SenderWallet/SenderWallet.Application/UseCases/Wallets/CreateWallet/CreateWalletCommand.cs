using MediatR;
using SenderWaller.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application.UseCases.Wallets.CreateWallet
{
    public record CreateWalletCommand(string Owner) : IRequest<Wallet>;

}
