using RentalService.Domain.Enums;

namespace RentalService.Domain.Entities;
public class Location
{
    public Guid Id { get; private set; }
    public Guid MotorcycleId { get; private set; }
    public Guid DeliveryManId { get; private set; }
    public RentalPlans Plan { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime ExpectedEndDate { get; private set; }
    public DateTime? DevolutionDate { get; private set; }

    public Location(Guid motorcycleId, Guid deliveryManId, RentalPlans plan, DateTime startDate)
    {
        Id = Guid.NewGuid();
        MotorcycleId = motorcycleId;
        DeliveryManId = deliveryManId;
        Plan = plan;
        StartDate = startDate.Date;
        ExpectedEndDate = StartDate.AddDays((int)plan).Date;
    }

    public void Finish(DateTime date)
    {
        DevolutionDate = date.Date;
    }

    public bool IsActive => DevolutionDate == null;

    public decimal CalcularValorTotal()
    {
        var expectedDays = (int)Plan;
        var dailyValue = GetDailyValue();
        var expectedTotal = expectedDays * dailyValue;

        if (!DevolutionDate.HasValue)
            return expectedTotal;

        var daysUsed = (DevolutionDate.Value - StartDate).Days;

        if (daysUsed < expectedDays)
        {
            var fine = GetFinesPerPlan();
            var remainingDays = expectedDays - daysUsed;
            return (daysUsed * dailyValue) + (remainingDays * dailyValue * fine);
        }

        if (daysUsed > expectedDays)
        {
            var additionalDays = daysUsed - expectedDays;
            return expectedTotal + (additionalDays * 50m);
        }

        return expectedTotal;
    }

    private decimal GetDailyValue() => Plan switch
    {
        RentalPlans.SevenDays => 30m,
        RentalPlans.FifteenDays => 28m,
        RentalPlans.ThirtyDays => 22m,
        RentalPlans.FortyFiveDays => 20m,
        RentalPlans.FiftyDays => 18m,
        _ => throw new InvalidOperationException("Plano inválido.")
    };

    private decimal GetFinesPerPlan() => Plan switch
    {
        RentalPlans.SevenDays => 0.20m,
        RentalPlans.FiftyDays => 0.40m,
        _ => 0m
    };


}
