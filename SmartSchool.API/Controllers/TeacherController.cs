using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class TeacherController: ControllerBase
{
    private readonly DBContext _context;

    public TeacherController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _context.Teachers?.ToList();

        if (list == null)
            return NoContent();

        return Ok(list);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var teacher = _context.Teachers?.FirstOrDefault(t => t.Id == id);

        if (teacher == null)
            return NotFound();

        return Ok(teacher);
    }

    [HttpPost]
    public IActionResult Post(Teacher teacher)
    {
        _context.Add(teacher);
        _context.SaveChanges();

        return Ok(teacher);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Teacher teacher)
    {
        var _teacher = _context.Teachers?.AsNoTracking().FirstOrDefault(t => t.Id == id);

        if (_teacher == null)
            return NotFound();

        _context.Update(teacher);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var teacher = _context.Teachers?.AsNoTracking().FirstOrDefault(t => t.Id == id);

        if (teacher == null)
            return NotFound();

        _context.Remove(teacher);
        _context.SaveChanges();

        return NoContent();
    }
}