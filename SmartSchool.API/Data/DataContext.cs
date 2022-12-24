using SmartSchool.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.API.Data;

public class DBContext: DbContext
{
    public DBContext(DbContextOptions<DBContext> options): base(options) { }

    public DbSet<Student>? Students { get; set; }
    public DbSet<Teacher>? Teachers { get; set; }
    public DbSet<Discipline>? Disciplines { get; set; }
    public DbSet<StudentsDisciplines>? StudentsDisciplines { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<StudentsDisciplines>()
            .HasKey(ad => new {ad.DisciplineId, ad.StudentId});
    }
}