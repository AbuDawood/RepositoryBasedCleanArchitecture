using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Schools.Commands.AddSchool;
using MediatR;

namespace CleanArchitecture.Application.Schools.Queries.GetSchool;
public class GetSchoolQuery : IRequest<SchoolDto>
{
}

public class GetSchoolQueryHandler : IRequestHandler<GetSchoolQuery, SchoolDto>
{
    public Task<SchoolDto> Handle(GetSchoolQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

