using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Schools.Commands.AddSchool;
public class AddSchoolCommand : IRequest<SchoolDto>
{
}

public class AddSchoolCommandHandler : IRequestHandler<AddSchoolCommand, SchoolDto>
{
    public Task<SchoolDto> Handle(AddSchoolCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
