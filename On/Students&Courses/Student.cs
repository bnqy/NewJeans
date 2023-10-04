namespace Students_Courses;

public class Student
{
    public int StudentID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set;}
    public ICollection<Course>? Courses { get; set; }
}
