namespace CodeAcademyNET8.Advanced___OOP.Classes.Accessibility;

internal class Circle(double radius) : Shape
{
    public double Radius { get; } = radius;

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}