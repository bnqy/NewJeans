using System.ComponentModel.DataAnnotations;
namespace Students_Courses;

public class Course
{
    public int CourseID { get; set; }

    [Required]
    [StringLength(100)]
    public string? CourseName { get; set; }

    public ICollection<Student>? Students { get; set; }

}
