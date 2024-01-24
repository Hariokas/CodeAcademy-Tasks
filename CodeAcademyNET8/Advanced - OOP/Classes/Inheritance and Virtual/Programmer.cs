namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;

internal class Programmer(string name, double salary, string programmingLanguage) : Employee(name, salary)
{
    public string ProgrammingLanguage { get; set; } = programmingLanguage;
}