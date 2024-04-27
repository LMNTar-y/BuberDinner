using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuId : ValueObject
{
    private MenuId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }
}