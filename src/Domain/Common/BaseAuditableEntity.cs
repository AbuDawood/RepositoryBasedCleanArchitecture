namespace CleanArchitecture.Domain.Common;

public interface IBaseAuditableEntity : IBaseEntity
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}

public interface IBaseAuditableEntity<TKey> : IBaseAuditableEntity, IBaseEntity<TKey>
{

}

public abstract class BaseAuditableEntity : BaseEntity, IBaseAuditableEntity
{
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IBaseAuditableEntity<TKey>
{
    protected BaseAuditableEntity()
    {
    }

    protected BaseAuditableEntity(TKey id) : base(id)
    {
    }

    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
