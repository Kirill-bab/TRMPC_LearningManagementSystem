using LearningManagementSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        var c = new Course(1, "CSharp");
        c.EnrollStudent(new List<int>{1,2,3});
        c.EnrollStudent(4);
        c.EnrollStudent(4);

        Console.WriteLine(c.HasStudent(1));
        Console.WriteLine(c.HasStudent(5));

        var cDto = new CourseDto(c.Id, c.Name, c.StudentsIds.ToList());
        var cDto2 = cDto with { Id = 2, Name = "Java" };

        Console.WriteLine(cDto);
        Console.WriteLine(cDto2);
        Console.WriteLine(cDto == cDto2);
    }
}