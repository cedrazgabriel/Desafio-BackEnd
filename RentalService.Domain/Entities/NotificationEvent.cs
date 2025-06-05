using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Domain.Entities;
public class NotificationEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EventType { get; set; } = null!;
    public string Data { get; set; } = null!;
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
}
