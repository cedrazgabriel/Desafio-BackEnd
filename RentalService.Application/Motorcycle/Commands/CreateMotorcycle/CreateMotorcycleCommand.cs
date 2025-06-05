using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Application.Motorcycle.Commands.CreateMotorcycle;
public record CreateMotorcycleCommand(string model, int year, string lincensePlate) : IRequest<Guid>;