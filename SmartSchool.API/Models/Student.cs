namespace SmartSchool.API.Models;

public class Student
{
    public Student(Guid id, string name, string lastName, string phone)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Phone = phone;
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? LastName { get; private set; }
    public string? Phone { get; private set; }
    public IEnumerable<StudentsDisciplines>? StudentsDisciplines { get; set; }
}