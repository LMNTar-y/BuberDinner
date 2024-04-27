using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    private HostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private static HostId Create(string hostId)
    {
        if (!Guid.TryParse(hostId, out var guidHostId))
        {
            throw new ArgumentException("Invalid HostId");
        }

        return new HostId(guidHostId);
    }

    public static HostId Create(Guid hostId)
    {
        return new HostId(hostId);
    }

    // Implicit conversion from string to HostId
    public static implicit operator HostId(string value)
    {
        return Create(value);
    }

    // Explicit conversion from HostId to string
    public static explicit operator string(HostId hostId)
    {
        return hostId.Value.ToString();
    }
}