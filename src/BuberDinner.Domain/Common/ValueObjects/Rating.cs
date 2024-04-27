using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    private Rating(float value)
    {
        Value = value;
    }

    public float Value { get; private set; }

    public static Rating CreateNew(float value)
    {
        return new Rating(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}