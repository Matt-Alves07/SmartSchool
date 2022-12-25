using SmartSchool.API.Models;

namespace SmartSchool.API.Data;

public interface IRepository
{
    void Add<T>(T entity) where T: class;
    void Update<T>(T entity) where T: class;
    void Delete<T>(T entity) where T: class;
    bool SaveChanges();

    #region Students
    Student GetStudentById(Guid id,bool includeTeachers = false);
    List<Student> GetStudents(bool includeTeachers = false);
    List<Student> GetStudentsByDisciplineId(Guid disciplineId, bool includeTeachers = false);
    #endregion

    #region Teachers
    Teacher GetTeacherById(Guid id, bool includeDiscipline = false);
    List<Teacher> GetTeachers(bool includeDiscipline = false);
    List<Teacher> GetTeachersByDisciplineId(Guid disciplineId, bool includeDiscipline = false);
    #endregion
}