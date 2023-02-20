namespace CleanArchitecture.Domain.Entities.Schools;

public class SchoolClassroom : BaseEntity
{
    public Guid SchoolId { get; protected set; }
    public Guid ClassroomId { get; protected set; }

    public override object[] GetKeys()
    {
        return new object[] { SchoolId, ClassroomId };
    }
}
