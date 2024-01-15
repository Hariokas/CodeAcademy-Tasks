namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Square
{
    public Square(double side)
    {
        Side = side;
    }

    public double Side { get; set; }

    public double Area()
    {
        return Side * Side;
    }

    public double Perimeter()
    {
        return 4 * Side;
    }
}