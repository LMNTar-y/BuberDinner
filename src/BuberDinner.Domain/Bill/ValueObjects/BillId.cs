using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects;

public class BillId : AggregateRootId<Guid>
{
    private BillId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}