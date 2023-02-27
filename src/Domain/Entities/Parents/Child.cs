namespace CleanArchitecture.Domain.Entities.Parents;

public class Child : BaseEntity<Guid>
{
    protected Child() { }

    internal protected Child(Guid id, string firstname, string lastname, int age, Guid parentId) : base(id)
    {
        Firstname = firstname;
        Lastname = lastname;
        Age = age;
        ParentId = parentId;
    }

    public string Firstname { get; protected set; }

    public string Lastname { get; protected set; }

    public int Age { get; protected set; }

    public Guid ParentId { get; protected set; }
}
