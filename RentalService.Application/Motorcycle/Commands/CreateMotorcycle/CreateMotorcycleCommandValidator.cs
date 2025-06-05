using FluentValidation;

namespace RentalService.Application.Motorcycle.Commands.CreateMotorcycle;
public class CreateMotorcycleCommandValidator : AbstractValidator<CreateMotorcycleCommand>  
{
    public CreateMotorcycleCommandValidator()
    {
        RuleFor(x => x.model).NotEmpty().MaximumLength(100);
        RuleFor(x => x.year).InclusiveBetween(2000, DateTime.Now.Year + 1);
        RuleFor(x => x.lincensePlate).NotEmpty().Length(7);
    }
}