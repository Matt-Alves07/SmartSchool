using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data;

public class Repository : IRepository
{
    private readonly DBContext _context;

    public Repository(DBContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class => _context.Add(entity);
    
    public void Update<T>(T entity) where T : class => _context.Update(entity);

    public void Delete<T>(T entity) where T : class => _context.Remove(entity);

    public bool SaveChanges() =>  (_context.SaveChanges() > 0);

    #region Students
    public Student GetStudentById(Guid id,bool includeTeachers = false)
    {
        IQueryable<Student> query = _context.Students;

        if (includeTeachers)
            query = query.Include(s => s.StudentsDisciplines).ThenInclude(sd => sd.Discipline).ThenInclude(d => d.Teacher);

        query = query.AsNoTracking().Where(s => s.Id == id);

        return query.FirstOrDefault();
    }

    public List<Student> GetStudents(bool includeTeachers = false)
    {
        IQueryable<Student> query = _context.Students;

        if (includeTeachers)
            query = query.Include(s => s.StudentsDisciplines).ThenInclude(sd => sd.Discipline).ThenInclude(d => d.Teacher);

        query = query.AsNoTracking().OrderBy(s => s.Name).OrderBy(s => s.LastName);

        return query.ToList();
    }

    public List<Student> GetStudentsByDisciplineId(Guid disciplineId, bool includeTeachers = false)
    {
        IQueryable<Student> query = _context.Students;

        if (includeTeachers)
            query = query.Include(s => s.StudentsDisciplines).ThenInclude(sd => sd.Discipline).ThenInclude(d => d.Teacher);

        query = query
                    .AsNoTracking()
                    .OrderBy(s => s.Name)
                    .OrderBy(s => s.LastName)
                    .Where(s => s.StudentsDisciplines.Any(ad => ad.DisciplineId == disciplineId));

        return query.ToList();
    }
    #endregion

    #region Teachers
    public Teacher GetTeacherById(Guid id, bool includeDiscipline = false)
    {
        IQueryable<Teacher> query = _context.Teachers;

        if (includeDiscipline)
            query = query.Include(t => t.Disciplines);

        query = query.AsNoTracking().Where(t => t.Id == id);

        return query.FirstOrDefault();
    }

    public List<Teacher> GetTeachers(bool includeDiscipline = false)
    {
        IQueryable<Teacher> query = _context.Teachers;

        if (includeDiscipline)
            query = query.Include(t => t.Disciplines);

        query = query.AsNoTracking().OrderBy(t => t.Name).OrderBy(t => t.LastName);

        return query.ToList();
    }

    public List<Teacher> GetTeachersByDisciplineId(Guid disciplineId, bool includeDiscipline = false)
    {
        IQueryable<Teacher> query = _context.Teachers;

        if (includeDiscipline)
            query = query.Include(t => t.Disciplines);

        query = query
                    .AsNoTracking()
                    .OrderBy(t => t.Name)
                    .OrderBy(t => t.LastName)
                    .Where(t => t.Disciplines.Any(ad => ad.Id == disciplineId));

        return query.ToList();
    }
    #endregion
}