using RentalService.Domain.Entities;

namespace RentalService.Application.Common.Interfaces;
public interface IMotocycleRepository
{
    Task<bool> LincensePlateExistsAsync(string placa);
    Task AddAsync(Moto motorcycle);
}
