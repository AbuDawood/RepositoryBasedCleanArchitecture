using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Classroom.Exceptions;

namespace CleanArchitecture.Domain.Entities.Classroom;

public class Classroom : BaseEntity<Guid>
{
    public string Code { get; set; }

    public Guid SchoolId { get; set; }

    public int MaxSize { get; protected set; }

    public ICollection<ClassroomStudent> Students { get; protected set; } = new HashSet<ClassroomStudent>();

    protected Classroom() { }

    public Classroom(string code, Guid schoolId, int maxSize)
    {
        Code = code;
        SchoolId = schoolId;
        MaxSize = maxSize;
    }

    protected internal void AddStudent(Guid studentId)
    {
        if (MaxSize <= Students.Count)
        {
            throw new ClassroomFullfilledException(Code);
        }

        Students.Add(new ClassroomStudent(studentId, this.Id));
    }

}
