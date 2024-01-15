namespace CodeAcademyNET8.Advanced___OOP.Classes.ClassMethods;

internal class Circle
{
    public double Radius { get; set; }

    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}