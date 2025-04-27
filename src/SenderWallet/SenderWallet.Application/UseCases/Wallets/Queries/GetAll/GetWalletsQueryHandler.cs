using MediatR;
using Microsoft.EntityFrameworkCore;
using SenderWallet.Application.Common.Data;
using SenderWallet.Application.Common.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderWallet.Application.UseCases.Wallets.Queries.GetAll
{
    public class GetWalletsQueryHandler: IRequestHandler<GetWalletsQuery, List<WalletDto>>
    {
        private readonly IWalletDbContext _dbContext;
        public GetWalletsQueryHandler(IWalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<WalletDto>> Handle(GetWalletsQuery query, CancellationToken cancellationToken)
        {
            var wallets=await _dbContext.Wallets.ToListAsync(cancellationToken);
            return wallets.Select(wallet=>new WalletDto
            {
                Id = wallet.Id,
                UserName=wallet.UserName,
                USDBalance=wallet.UsdBalance,
                TJSBalance=wallet.TjsBalance
            }).ToList();
        }
    }
}
