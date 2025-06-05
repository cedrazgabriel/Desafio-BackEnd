using RentalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Application.Common.Interfaces;
public interface INotificationEventRepository
{
    Task SaveAsync (NotificationEvent notificationEvent);
}
