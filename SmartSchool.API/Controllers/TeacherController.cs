using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class TeacherController: ControllerBase
{
    public TeacherController() { }

    [HttpGet]
    public IActionResult Get() => Ok("Teachers=> Leandro, Carlos, Sílvio, Fátima.");
}