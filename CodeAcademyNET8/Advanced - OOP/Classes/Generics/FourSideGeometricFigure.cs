namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal class FourSideGeometricFigure
{
    public string Name { get; set; }
    public double Base { get; set; }
    public double Height { get; set; }

    public double GetArea()
    {
        return Base * Height;
    }

    public override string ToString()
    {
        return $"Figure: {Name}; Base: {Base}; Height: {Height}";
    }
}