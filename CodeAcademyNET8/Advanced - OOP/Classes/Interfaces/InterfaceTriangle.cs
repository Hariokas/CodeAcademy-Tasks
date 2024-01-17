namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal class InterfaceTriangle (double sideA, double sideB, double sideC) : IPolygon, IWriteToFile
{

    public double SideA { get; set; } = sideA;
    public double SideB { get; set; } = sideB;
    public double SideC { get; set; } = sideC;

    public double GetArea()
    {
        var s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
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
        return $"Triangle with sides [{SideA}], [{SideB}], [{SideC}], area: [{GetArea()}]";
    }

}