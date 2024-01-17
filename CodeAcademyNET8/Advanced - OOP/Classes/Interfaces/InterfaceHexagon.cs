namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfaceHexagon(double sideLength) : IPolygon, IWriteToFile
{
    public double SideLength { get; set; } = sideLength;

    public double GetArea()
    {
        return 3 * Math.Sqrt(3) * Math.Pow(SideLength, 2) / 2;
    }

    public int CompareTo(IPolygon? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return GetArea().CompareTo(other.GetArea());
    }


    public void WriteToFile(string path)
    {
        File.AppendAllText(path, $"{ToString()}\n");
        Console.WriteLine($"Writing to file: [{Path.GetFullPath(path)}]");
    }

    public override string ToString()
    {
        return $"Hexagon with side length [{SideLength}], area: [{GetArea()}]";
    }
}