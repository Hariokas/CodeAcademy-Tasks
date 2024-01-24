namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility;

internal class Teacher(string name, int age, string subject) : PersonAccessibility(name, age)
{
    public string Subject { get; } = subject;

    public string GetSubject()
    {
        return Subject;
    }
}