using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class ReservationId : AggregateRootId<Guid>
{
    private ReservationId(Guid value)
    {
        Value = value;
    }
    public override Guid Value { get; protected set; }

    public static ReservationId CreateNew()
    {
        return new ReservationId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}