namespace CleanArchitecture.Domain.Entities.Classroom;

public class ClassroomStudent : BaseEntity
{

    protected ClassroomStudent() { }

    public ClassroomStudent(Guid studentId, Guid classroomId)
    {
        StudentId = studentId;
        ClassroomId = classroomId;
    }

    public Guid StudentId { get; protected set; }

    public Guid ClassroomId { get; protected set; }

    public override object[] GetKeys()
    {
        return new object[] { StudentId, ClassroomId };
    }
}