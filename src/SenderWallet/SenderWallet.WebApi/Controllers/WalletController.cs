using MediatR;
using Microsoft.AspNetCore.Mvc;
using SenderWallet.Application.UseCases.Wallets.Commands.CreateWallet;
using SenderWallet.Application.UseCases.Wallets.Commands.ExchangeCurrencyWallet;
using SenderWallet.Application.UseCases.Wallets.Queries.GetAll;

namespace SenderWallet.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetWallets()
        {
            var wallets=await _mediator.Send(new GetWalletsQuery());
            return Ok(wallets);
        }
        [HttpPost("CreateWallet")]
        public async Task<IActionResult> CreateWallet([FromBody] CreateWalletCommand command)
        {
            var result=await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("exchange")]
        public async Task<IActionResult> Exchange([FromBody] ExchangeCurrencyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ExchangeId = result });
        }
    }
}
