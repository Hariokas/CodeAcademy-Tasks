namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfacePentagon(double sideLength) : IPolygon, IWriteToFile
{
    public double SideLength { get; set; } = sideLength;

    public double GetArea()
    {
        return 1.0 / 4 * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * Math.Pow(SideLength, 2);
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
        Console.WriteLine($"Writing to file: [{path}]");
    }

    public override string ToString()
    {
        return $"Pentagon with side length [{SideLength}], area: [{GetArea()}]";
    }
}