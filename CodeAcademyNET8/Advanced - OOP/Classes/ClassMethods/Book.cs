namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Book
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}, Description: {Description}, Author: {Author}, Pages: {Pages}";
    }
}