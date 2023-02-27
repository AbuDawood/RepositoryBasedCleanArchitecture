using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Classrooms.Commands.AddClassroom;
public class AddClassroomCommand : IRequest<ClassroomDto>
{
}


public class AddClassroomCommandHandler : IRequestHandler<AddClassroomCommand, ClassroomDto>
{
    public Task<ClassroomDto> Handle(AddClassroomCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}