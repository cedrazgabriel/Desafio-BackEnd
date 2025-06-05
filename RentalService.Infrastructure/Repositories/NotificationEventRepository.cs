using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Infrastructure.Repositories;
public class NotificationEventRepository : INotificationEventRepository
{
    private readonly AppDbContext _context;

    public NotificationEventRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(NotificationEvent notificationEvent)
    {
        _context.NotificationEvents.Add(notificationEvent);
        await _context.SaveChangesAsync();
    }
}