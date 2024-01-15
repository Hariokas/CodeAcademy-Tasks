namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Person4Task
{
    public Person4Task(string name, int age, Address address)
    {
        Name = name;
        Age = age;
        Address = address;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Address: [{Address}]";
    }
}