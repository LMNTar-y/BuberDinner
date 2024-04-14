using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class ReservationId : ValueObject
{
    private ReservationId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; set; }

    public static ReservationId CreateNew()
    {
        return new ReservationId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}