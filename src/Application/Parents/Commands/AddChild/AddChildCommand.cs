using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitecture.Application.Parents.Commands.AddChild;
public class AddChildCommand : IRequest<ChildDto>
{
}

public class AddChildCommandHandler : IRequestHandler<AddChildCommand, ChildDto>
{
    public Task<ChildDto> Handle(AddChildCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
