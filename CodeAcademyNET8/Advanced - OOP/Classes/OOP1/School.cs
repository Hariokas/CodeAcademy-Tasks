namespace CodeAcademyNET8.Advanced___OOP.Classes;

internal class School
{
    public School(string name, string city)
    {
        Name = name;
        City = city;
    }

    public School(string name, string city, int numberOfStudents) : this(name, city)
    {
        NumberOfStudents = numberOfStudents;
    }

    public string Name { get; set; }
    public string City { get; set; }
    public int NumberOfStudents { get; set; }
}