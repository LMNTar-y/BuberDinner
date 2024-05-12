using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.ValuesObjects;

public class GuestRatingId : AggregateRootId<Guid>
{
    private GuestRatingId(Guid value)
    {
        Value = value;
    }
    public override Guid Value { get; protected set; }

    public static GuestRatingId CreateNew()
    {
        return new GuestRatingId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}