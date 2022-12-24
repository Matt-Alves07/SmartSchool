using SmartSchool.API.Models;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController: ControllerBase
{
    private readonly DBContext _context;

    public StudentController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = _context.Students?.ToList();

        if (list is null)
            return NoContent();

        return Ok(list);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var student = _context.Students?.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult Post(Student student)
    {
        _context.Add(student);
        _context.SaveChanges();

        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Student student)
    {
        var _student = _context.Students?.AsNoTracking().FirstOrDefault(s => s.Id == id);

        if (_student == null)
            return NotFound();

        _context.Update(student);
        _context.SaveChanges();

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var student = _context.Students?.AsNoTracking().FirstOrDefault(s => s.Id == id);

        if (student == null)
            return BadRequest();

        _context.Remove(student);
        _context.SaveChanges();

        return NoContent();
    }
}