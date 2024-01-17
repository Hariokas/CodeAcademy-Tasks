namespace CodeAcademyNET8.Advanced___OOP.Classes.Interfaces;

internal interface IPolygon : IComparable<IPolygon>, IWriteToFile
{
    public double GetArea();
}