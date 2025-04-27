using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Common.Data;
using NotificationService.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.UseCases.WalletNotification.Queries.GetAll
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, List<NotificationDto>>
    {
        private readonly INotificationDbContext _context;

        public GetNotificationsQueryHandler(INotificationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationDto>> Handle(GetNotificationsQuery query, CancellationToken cancellationToken)
        {
            var notifications = await _context.Notifications.ToListAsync(cancellationToken);

            return notifications.Select(wallet => new NotificationDto
            {
                Id = wallet.Id,
                Amount = wallet.Amount,
                CurrencyFrom = wallet.CurrencyFrom,
                CurrencyTo = wallet.CurrencyTo,
                TransferDate = wallet.TransferDate,
                WalletId = wallet.WalletId, 
                WalletSentId = wallet.WalletSentId 
            }).ToList();
        }
    }

}
