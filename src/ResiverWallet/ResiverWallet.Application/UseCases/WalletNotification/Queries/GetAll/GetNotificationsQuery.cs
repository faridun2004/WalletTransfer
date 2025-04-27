using MediatR;
using NotificationService.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.UseCases.WalletNotification.Queries.GetAll
{
    public record GetNotificationsQuery(): IRequest<List<NotificationDto>>;

}
