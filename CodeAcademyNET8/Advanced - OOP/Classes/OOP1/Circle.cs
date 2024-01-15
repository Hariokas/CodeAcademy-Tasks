namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Circle
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; set; }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}