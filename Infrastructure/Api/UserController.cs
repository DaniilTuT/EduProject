using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAllUser([FromServices] UserService service)
    {
        
        var users = service.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("Get")]
    public IActionResult GetUser([FromServices] UserService service, [FromBody] User request)
    {
        var user = service.GetUserById(request.Id);
        return Ok(user);
    }

    [HttpPost("Create")]
    public IActionResult CreateUser([FromServices] UserService service, [FromBody] User request)
    {
        var user = service.CreateUser(request);
        return Ok(user);
    }

    [HttpPut("Update")]
    public IActionResult UpdateUser([FromServices] UserService service, [FromBody] User request)
    {
        var updatedUser = service.UpdateUser(request);
        return Ok(updatedUser);
    }

    [HttpDelete("Delete")]
    public IActionResult DeleteUser([FromServices] UserService service, Guid id)
    {
        service.Delete(id);
        return Ok(true);
    }
}