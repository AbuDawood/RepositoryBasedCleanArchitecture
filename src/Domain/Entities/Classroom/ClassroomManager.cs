using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Classroom.Exceptions;
using CleanArchitecture.Domain.Entities.Parents;

namespace CleanArchitecture.Domain.Entities.Classroom;
public class ClassroomManager
{
    private readonly IClassroomRepository _classroomRepository;
    private readonly IParentRepository _parentRepository;

    public ClassroomManager(IClassroomRepository classroomRepository, IParentRepository parentRepository)
    {
        _classroomRepository = classroomRepository;
        _parentRepository = parentRepository;
    }



    public async Task AddAsync(Classroom targetClassroom, Guid studentId, CancellationToken cancellationToken = default)
    {

        if (targetClassroom == null)
        {
            throw new ArgumentNullException(nameof(targetClassroom));
        }


        var targetChild = await _parentRepository.FindChild(studentId, cancellationToken);

        // check if available
        if (targetChild == null)
        {
            throw new StudentNotFoundException(studentId);
        }

        // check if not assigned before
        var hostClassroom = await _classroomRepository.FindAsync(e => e.Students.Any(e => e.StudentId == studentId));

        if (hostClassroom != null)
        {
            throw new StudentAlreadyRegisteredException(targetChild.Firstname, hostClassroom.Code);
        }

        targetClassroom.AddStudent(studentId);
    }


}
