using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderService.Application.Common.DTOs;

namespace OrderService.Application.UseCases.ExchangeWallets.Queries.GetAll
{
    public record GetExchangeWalletInOrderQuery(): IRequest<List<ExchangeWalletDto>>;
    
}
