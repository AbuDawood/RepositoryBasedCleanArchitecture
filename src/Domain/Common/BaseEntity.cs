using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Common;


/// <summary>
/// Defines an entity. It's primary key may not be "Id" or it may have a composite primary key.
/// Use <see cref="IBaseEntity{TKey}"/> where possible for better integration to repositories and other structures in the framework.
/// </summary>
public interface IBaseEntity
{
    /// <summary>
    /// Returns an array of ordered keys for this entity.
    /// </summary>
    /// <returns></returns>
    object[] GetKeys();

    IReadOnlyCollection<BaseEvent> DomainEvents { get; }

    void AddDomainEvent(BaseEvent domainEvent);

    void RemoveDomainEvent(BaseEvent domainEvent);

    void ClearDomainEvents();
}

/// <summary>
/// Defines an entity with a single primary key with "Id" property.
/// </summary>
/// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
public interface IBaseEntity<TKey> : IBaseEntity
{
    /// <summary>
    /// Unique identifier for this entity.
    /// </summary>
    TKey Id { get; }
}

public abstract class BaseEntity : IBaseEntity
{
    private readonly List<BaseEvent> _domainEvents = new();

    protected BaseEntity()
    {
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Keys = {string.Join(", ", GetKeys())}";
    }

    public abstract object[] GetKeys();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    //public bool EntityEquals(IBaseEntity other)
    //{
    //    return EntityHelper.EntityEquals(this, other);
    //}
}

public abstract class BaseEntity<TKey> : BaseEntity, IBaseEntity<TKey>
{
    public virtual TKey Id { get; protected set; }

    protected BaseEntity()
    {
    }

    protected BaseEntity(TKey id)
    {
        Id = id;
    }

    public override object[] GetKeys()
    {
        return new object[] { Id };
    }

    public override string ToString()
    {
        return $"[ENTITY: {GetType().Name}] Id = {Id}";
    }


}




