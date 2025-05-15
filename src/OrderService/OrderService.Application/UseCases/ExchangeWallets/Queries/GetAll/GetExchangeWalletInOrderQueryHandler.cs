using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Common.Data;
using OrderService.Application.Common.DTOs;

namespace OrderService.Application.UseCases.ExchangeWallets.Queries.GetAll
{
    public class GetExchangeWalletInOrderQueryHandler : IRequestHandler<GetExchangeWalletInOrderQuery, List<ExchangeWalletDto>>
    {
        private readonly IOrderDbContext _context;

        public GetExchangeWalletInOrderQueryHandler(IOrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExchangeWalletDto>> Handle(GetExchangeWalletInOrderQuery query, CancellationToken cancellationToken)
        {
            var notifications = await _context.ExchangeWallets.ToListAsync(cancellationToken);

            return notifications.Select(wallet => new ExchangeWalletDto
            {
                Id = wallet.Id,
                Amount = wallet.Amount,
                CurrencyFrom = wallet.CurrencyFrom,
                CurrencyTo = wallet.CurrencyTo,
                WalletId = wallet.WalletId,
                WalletSentId = wallet.WalletSentId
            }).ToList();

        }
    }
}
