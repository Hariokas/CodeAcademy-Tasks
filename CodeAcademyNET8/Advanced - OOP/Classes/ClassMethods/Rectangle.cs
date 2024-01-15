namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }

    public double GetArea()
    {
        return Height * Width;
    }

    public double GetPerimeter()
    {
        return 2 * (Height + Width);
    }
}