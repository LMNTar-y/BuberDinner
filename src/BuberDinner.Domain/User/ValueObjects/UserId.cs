using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserId Create()
    {
        return new UserId(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}