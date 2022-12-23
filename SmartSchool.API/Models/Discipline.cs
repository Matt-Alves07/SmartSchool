namespace SmartSchool.API.Models;

public class Discipline
{
    public Discipline(Guid id, string name, Guid teacherId)
    {
        Id = id;
        Name = name;
        TeacherId = teacherId;
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public Guid TeacherId { get; private set; }
    public Teacher? Teacher { get; set; }

    public IEnumerable<StudentsDisciplines>? StudentsDisciplines { get; set; }
}