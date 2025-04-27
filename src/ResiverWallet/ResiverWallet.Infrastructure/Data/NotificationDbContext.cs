using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Common.Data;
using NotificationService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Data
{
    public class NotificationDbContext: DbContext, INotificationDbContext
    {
        public NotificationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Notification> Notifications=>Set<Notification>();
    }
}
