using RentalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Application.Common.Interfaces;

public interface IEventPublisher
{
    Task PublishRegisteredMotorcycle(Moto moto);
}