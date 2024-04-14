using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.ValuesObjects;

public class GuestRatingId : ValueObject
{
    private GuestRatingId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; set; }

    public static GuestRatingId CreateNew()
    {
        return new GuestRatingId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}