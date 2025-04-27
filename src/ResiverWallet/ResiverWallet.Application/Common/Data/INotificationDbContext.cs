
using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Common.Data
{
    public interface INotificationDbContext
    {
        public DbSet<Notification> Notifications { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
