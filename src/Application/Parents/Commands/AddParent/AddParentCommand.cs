using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Parents.Commands.AddParent;
public class AddParentCommand : IRequest<ParentDto>
{
}



public class AddParentCommandHandler : IRequestHandler<AddParentCommand, ParentDto>
{
    public AddParentCommandHandler()
    {

    }

    public Task<ParentDto> Handle(AddParentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
