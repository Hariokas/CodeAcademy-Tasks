namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Triangle
{
    public Triangle(double @base, double height, double sideA, double sideB, double sideC)
    {
        Base = @base;
        Height = height;
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double Base { get; set; }
    public double Height { get; set; }
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public double Area()
    {
        return 0.5 * Base * Height;
    }

    public double Perimeter()
    {
        return SideA + SideB + SideC;
    }
}