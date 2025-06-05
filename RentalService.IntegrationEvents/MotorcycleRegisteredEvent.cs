using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.IntegrationEvents;
public class MotorcycleRegisteredEvent
{
    public Guid Id { get; set; }
    public string Model { get; set; } = null!;
    public int Year { get; set; }
    public string LicensePlate { get; set; } = null!;
}
