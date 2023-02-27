using CleanArchitecture.Application.Schools.Commands.AddSchool;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class SchoolController : ApiControllerBase
{
    [HttpPost("[action]")]
    public async Task<SchoolDto> AddSchoolAsync(AddSchoolCommand cmd)
    {
        return await Mediator.Send(cmd);
    }
}
