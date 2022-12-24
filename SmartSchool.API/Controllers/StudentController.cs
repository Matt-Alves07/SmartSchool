using SmartSchool.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController: ControllerBase
{
    public StudentController() {  }

    [HttpGet]
    public IActionResult Get() => Ok(new Student(Guid.NewGuid(),"Aluno","de Teste","(99)999-999-999"));
}