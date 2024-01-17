namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfaceQuadrilateral(double sideA, double sideB) : IPolygon, IWriteToFile
{
    public double SideA { get; set; } = sideA;
    public double SideB { get; set; } = sideB;

    public double GetArea()
    {
        return SideA * SideB;
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
        return $"Quadrilateral with sides [{SideA}], [{SideB}], area: [{GetArea()}]";
    }
}