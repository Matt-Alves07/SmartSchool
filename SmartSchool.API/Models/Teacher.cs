namespace SmartSchool.API.Models;

public class Teacher
{
    public Teacher(Guid id, string name, string lastName)
    {
        Id = id;
        Name = name;
        LastName = lastName;
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? LastName { get; private set; }
    public IEnumerable<Discipline> Disciplines { get; set; }
}