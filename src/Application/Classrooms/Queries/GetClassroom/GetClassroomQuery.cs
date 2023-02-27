using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Classrooms.Commands.AddClassroom;
using MediatR;

namespace CleanArchitecture.Application.Classrooms.Queries.GetClassroom;
public class GetClassroomQuery : IRequest<ClassroomDto>
{
}

public class GetClassroomQueryHandler : IRequestHandler<GetClassroomQuery, ClassroomDto>
{
    public Task<ClassroomDto> Handle(GetClassroomQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
