using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;
        private readonly IWalletDbContext _dbContext;
        public GetWalletsQueryHandler(IWalletDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<WalletDto>> Handle(GetWalletsQuery query, CancellationToken cancellationToken)
        {
            var wallets = await _dbContext.Wallets
               .ProjectTo<WalletDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
            return wallets;
        }
    }
}
