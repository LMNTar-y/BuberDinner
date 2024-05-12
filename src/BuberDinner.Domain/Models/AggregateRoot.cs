namespace BuberDinner.Domain.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId> where TId : AggregateRootId<TIdType>
{
    public new AggregateRootId<TIdType> Id { get; protected set; }

    public TIdType IdValue => Id.Value;
    protected AggregateRoot(TId id) : base(id)
    {
        Id = id;
    }

    protected AggregateRoot()
    {
    }   
}