namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;

internal class Employee(string name, double salary)
{
    public string Name { get; set; } = name;
    public double Salary { get; set; } = salary;

    public virtual string Greeting()
    {
        return $"Hello, my name is {Name} and I am an employee";
    }
}