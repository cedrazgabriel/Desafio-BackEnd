using RentalService.Domain.ValueObjects;

namespace RentalService.Domain.Entities;
public class Moto
{
    public Guid Id { get; private set; }
    public string Model { get; private set; } = string.Empty;
    public int Year { get; private set; }
    public LicensePlate LicensePlate { get; private set; }

    public Moto(string model, int year, LicensePlate licensePlate)
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
