namespace BuberDinner.Domain.Models;

public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>, IEqualityComparer<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected set; } = id;

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> other && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !left.Equals(right);
    }

    public bool Equals(Entity<TId>? x, Entity<TId>? y)
    {
        if (x is null || y is null)
        {
            return false;
        }

        return x.Equals((object?)y);
    }

    public int GetHashCode(Entity<TId> obj)
    {
        return obj.GetHashCode();
    }
}