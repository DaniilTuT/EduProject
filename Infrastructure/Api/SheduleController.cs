using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api;

[ApiController]
[Route("api/[controller]")]
public class SheduleController: ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAllShedule([FromServices] SheduleService service)
    {
        var shedules = service.GetAllShedules();
        return Ok(shedules);
    }

    [HttpGet("Get")]
    public IActionResult GetShedule([FromServices] SheduleService service, [FromBody] Shedule request)
    {
        var shedule = service.GetSheduleById(request.Id);
        return Ok(shedule);
    }

    [HttpPost("Create")]
    public IActionResult CreateShedule([FromServices] SheduleService service, [FromBody] Shedule request)
    {
        var shedule = service.CreateShedule(request);
        return Ok(shedule);
    }

    [HttpPut("Update")]
    public IActionResult UpdateShedule([FromServices] SheduleService service, [FromBody] Shedule request)
    {
        var updatedShedule = service.UpdateShedule(request);
        return Ok(updatedShedule);
    }

    [HttpDelete("Delete")]
    public IActionResult DeleteShedule([FromServices] SheduleService service, Guid id)
    {
        service.Delete(id);
        return Ok(true);
    }
}