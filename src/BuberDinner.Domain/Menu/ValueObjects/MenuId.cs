using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuId : AggregateRootId<Guid>
{
    private MenuId(Guid value)
    {
        Value = value;
    }

    public sealed override Guid Value { get; protected set; }

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