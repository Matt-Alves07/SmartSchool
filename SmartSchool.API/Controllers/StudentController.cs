using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController: ControllerBase
{
    public StudentController() {  }

    [HttpGet]
    public IActionResult Get() => Ok("Alunos=> Marta, Paula, Lucas, Rafaela");
}