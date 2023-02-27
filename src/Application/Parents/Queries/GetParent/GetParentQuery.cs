using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Parents.Commands.AddParent;
using MediatR;

namespace CleanArchitecture.Application.Parents.Queries.GetParent;
public class GetParentQuery : IRequest<ParentDto>
{
}


public class GetParentQueryHandler : IRequestHandler<GetParentQuery, ParentDto>
{
    public Task<ParentDto> Handle(GetParentQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
