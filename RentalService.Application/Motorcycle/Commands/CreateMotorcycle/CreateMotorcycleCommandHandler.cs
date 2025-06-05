using MediatR;
using RentalService.Application.Common.Interfaces;
using RentalService.Domain.Entities;
using RentalService.Domain.ValueObjects;



namespace RentalService.Application.Motorcycle.Commands.CreateMotorcycle;
public class CreateMotorcycleCommandHandler : IRequestHandler<CreateMotorcycleCommand, Guid>
{
    private readonly IMotocycleRepository _motorcycleRepository;
    private readonly IEventPublisher _eventPublisher;

    public CreateMotorcycleCommandHandler(IMotocycleRepository motorcycleRepository, IEventPublisher eventPublisher)
    {
        _motorcycleRepository = motorcycleRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
    {
        if (await _motorcycleRepository.LincensePlateExistsAsync(request.lincensePlate))
            throw new InvalidOperationException("There is already a motorcycle with this plate");

        var motorcycle = new Moto(request.model, request.year, new LicensePlate(request.lincensePlate));
        await _motorcycleRepository.AddAsync(motorcycle);

        await _eventPublisher.PublishRegisteredMotorcycle(motorcycle);

        return motorcycle.Id;
    }
}   
