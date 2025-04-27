using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.UseCases.WalletNotification.Queries.GetAll;

namespace ResiverWallet.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _mediator.Send(new GetNotificationsQuery());

            if (notifications == null || !notifications.Any())
            {
                return NotFound("No notifications found.");
            }
            return Ok(notifications); 
        }
    }
}
