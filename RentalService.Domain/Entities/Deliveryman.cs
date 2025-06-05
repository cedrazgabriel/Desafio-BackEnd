using RentalService.Domain.Enums;
using RentalService.Domain.ValueObjects;

namespace RentalService.Domain.Entities;
public class Deliveryman
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public CNPJ Cnpj { get; private set; }
    public DateTime BirthDate { get; private set; }
    public CNHNumber CnhNumber { get; private set; }
    public CnhType CnhType { get; private set; }
    public string? CnhImagePath { get; private set; }

    public Deliveryman(string name, CNPJ cnpj, DateTime birthDate, CNHNumber cnhNumber, CnhType cnhType)
    {
        Id = Guid.NewGuid();
        Name = name;
        Cnpj = cnpj;
        BirthDate = birthDate;
        CnhNumber = cnhNumber;
        CnhType = cnhType;
    }

    public void UpdateImageCnh(string path)
    {
        CnhImagePath = path;
    }

    public bool CanRentMotorcycle() => CnhType == CnhType.A || CnhType == CnhType.AB;
}
