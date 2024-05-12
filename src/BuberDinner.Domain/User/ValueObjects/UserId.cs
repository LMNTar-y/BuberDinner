using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public class UserId : AggregateRootId<Guid>
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static UserId Create()
    {
        return new UserId(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}