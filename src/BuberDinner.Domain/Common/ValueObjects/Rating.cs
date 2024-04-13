using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    private Rating(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }

    public static Rating CreateNew(double value)
    {
        return new Rating(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}