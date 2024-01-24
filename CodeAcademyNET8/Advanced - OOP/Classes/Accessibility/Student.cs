namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility;

internal class Student(string name, int age, string studentId) : PersonAccessibility(name, age)
{
    protected string StudentId { get; } = studentId;

    public string GetStudentId()
    {
        return StudentId;
    }
}