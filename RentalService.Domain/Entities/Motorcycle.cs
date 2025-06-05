using RentalService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentalService.Domain.Entities;
public class Motorcycle
{
    public Guid Id { get; private set; }
    public string Model { get; private set; } = string.Empty;
    public int Year { get; private set; }
    public LicensePlate LicensePlate { get; private set; }

    public Motorcycle(string model, int year, LicensePlate licensePlate)
    {
        Id = Guid.NewGuid();
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
    }

    public void UpdateLicensePlate(LicensePlate newLicensePlate)
    {
        LicensePlate = newLicensePlate;
    }
}
