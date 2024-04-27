using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    private AverageRating(float value, int numRating)
    {
        Value = value;
        NumRating = numRating;
    }

    public float Value { get; private set; }
    public int NumRating { get; private set; }

    public static AverageRating CreateNew(float value, int numRating)
    {
        return new AverageRating(value, numRating);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRating;
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRating) + rating.Value) / ++NumRating;
    }

    internal void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRating) - rating.Value) / --NumRating;
    }
}