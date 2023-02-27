using CleanArchitecture.Application.Parents.Commands.AddChild;
using CleanArchitecture.Application.Parents.Commands.AddParent;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ParentController : ApiControllerBase
{


    [HttpPost("[action]")]
    public async Task<ParentDto> AddAsync(AddParentCommand cmd)
    {
        return await Mediator.Send(cmd);
    }

    [HttpPost("[action]")]
    public async Task<ChildDto> AddChildAsync(AddChildCommand cmd)
    {
        return await Mediator.Send(cmd);
    }

}
