using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuSectionId : AggregateRootId<Guid>
{
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }
}