using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Classrooms.Commands.AddClassroom;
using MediatR;

namespace CleanArchitecture.Application.Classrooms.Commands.RegisterStudent;
public class RegisterStudentCommand : IRequest<ClassroomDto>
{
}

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, ClassroomDto>
{
    public Task<ClassroomDto> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
