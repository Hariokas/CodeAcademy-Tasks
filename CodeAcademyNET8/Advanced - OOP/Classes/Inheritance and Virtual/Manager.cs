namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;

internal class Manager(string name, double salary, List<Employee> employees) : Employee(name, salary)
{
    public List<Employee> Employees { get; set; } = employees;

    public void PrintProgrammersInfo()
    {
        foreach (var employee in Employees)
            if (employee is Programmer programmer)
                Console.WriteLine(
                    $"Programmer {programmer.Name} - {programmer.Salary} EUR - {programmer.ProgrammingLanguage}");
    }

    public override string Greeting()
    {
        return $"Hello, my name is {Name} and I am a manager";
    }
}