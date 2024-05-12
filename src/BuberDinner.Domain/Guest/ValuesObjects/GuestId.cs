using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValuesObjects;

public class GuestId : AggregateRootId<Guid>
{
    private GuestId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static GuestId CreateUnique()
    {
        return new GuestId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}