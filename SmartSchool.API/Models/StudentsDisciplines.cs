namespace SmartSchool.API.Models;

public class StudentsDisciplines
{
    public StudentsDisciplines(Guid studentId, Guid disciplineId)
    {
        StudentId = studentId;
        DisciplineId = disciplineId;
    }

    public Guid StudentId { get; private set; }
    public Student? Student { get; set; }
    public Guid DisciplineId { get; private set; }
    public Discipline? Discipline { get; set; }
}