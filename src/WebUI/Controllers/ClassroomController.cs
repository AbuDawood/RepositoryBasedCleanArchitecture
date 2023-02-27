using CleanArchitecture.Application.Classrooms.Commands.AddClassroom;
using CleanArchitecture.Application.Classrooms.Commands.RegisterStudent;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ClassroomController : ApiControllerBase
{

    [HttpPost("[action]")]
    public async Task<ClassroomDto> AddAsync(AddClassroomCommand cmd)
    {
        return await Mediator.Send(cmd);
    }

    [HttpPost("[action]")]
    public async Task<ClassroomDto> RegisterStudentAsync(RegisterStudentCommand cmd)
    {
        return await Mediator.Send(cmd);
    }

}
