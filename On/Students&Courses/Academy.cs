using static System.Console;
using Microsoft.EntityFrameworkCore;

namespace Students_Courses;

public class Academy:DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        string path = Path.Combine(Environment.CurrentDirectory, "Academy.db");
        WriteLine($"Using {path} database file.");

        //optionsBuilder.UseSqlite($"Filename={path}");
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Academy;Integrated Security=true;MultipleActiveResultSets=true;");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(30).IsRequired();


        Student alice = new()
        {
            StudentID = 1,
            FirstName = "Alice",
            LastName = "Jones"
        };
        Student bob = new()
        {
            StudentID = 2,
            FirstName = "Bob",
            LastName = "Smith"
        };
        Student cecilia = new()
        {
            StudentID = 3,
            FirstName = "Cecilia",
            LastName = "Ramirez"
        };
        Course csharp = new()
        {
            CourseID = 1,
            CourseName = "C# 10 and .NET 6",
        };
        Course webdev = new()
        {
            CourseID = 2,
            CourseName = "Web Development",
        };

        Course python = new()
        {
            CourseID = 3,
            CourseName = "Python for Beginners",
        };
        modelBuilder.Entity<Student>().HasData(alice, bob, cecilia);
        modelBuilder.Entity<Course>().HasData(csharp, webdev, python);
        modelBuilder.Entity<Course>().HasMany(c => c.Students).WithMany(s => s.Courses).UsingEntity(e => e.HasData(
       
        new { CoursesCourseID = 1, StudentsStudentID = 1 },
        new { CoursesCourseID = 1, StudentsStudentID = 2 },
        new { CoursesCourseID = 1, StudentsStudentID = 3 },
        
        new { CoursesCourseID = 2, StudentsStudentID = 2 },
       
        new { CoursesCourseID = 3, StudentsStudentID = 3 }
        ));
    }
}
