using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class TeacherController: ControllerBase
{
    private readonly IRepository _repository;

    public TeacherController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _repository.GetTeachers(true);
        if (list == null)
            return NoContent();

        return Ok(list);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var teacher = _repository.GetTeacherById(id, true);
        if (teacher == null)
            return NotFound();

        return Ok(teacher);
    }

    [HttpPost]
    public IActionResult Post(Teacher teacher)
    {
        _repository.Add(teacher);
        if (_repository.SaveChanges())
            return Ok(teacher);

        return BadRequest("Teacher not registered.");
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Teacher teacher)
    {
        var _teacher = _repository.GetTeacherById(id);
        if (_teacher == null)
            return NotFound();

        _repository.Update(teacher);
        if (_repository.SaveChanges())
            return Ok(teacher);

        return BadRequest("Teacher not updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var teacher = _repository.GetTeacherById(id);
        if (teacher == null)
            return NotFound();

        _repository.Delete(teacher);
        if (_repository.SaveChanges())
            return NoContent();

        return BadRequest("Teacher not removed");
    }
}