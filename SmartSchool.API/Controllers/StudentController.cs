using SmartSchool.API.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController: ControllerBase
{
    private readonly IRepository _repository;

    public StudentController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _repository.GetStudents(true);
        if (list == null)
            return NoContent();

        return Ok(list);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var student = _repository.GetStudentById(id, true);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult Post(Student student)
    {
        _repository.Add(student);
        if (_repository.SaveChanges())
            return Ok(student);

        return BadRequest("Student not registered.");
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Student student)
    {
        var _student = _repository.GetStudentById(id);
        if (_student == null)
            return NotFound();

        _repository.Update(student);
        if(_repository.SaveChanges())
            return Ok(student);

        return BadRequest("Student not updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var student = _repository.GetStudentById(id);
        if (student == null)
            return NotFound();

        _repository.Delete(student);
        if (_repository.SaveChanges())
            return NoContent();

        return BadRequest("Student not removed.");
    }
}