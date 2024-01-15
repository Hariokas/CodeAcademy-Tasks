namespace CodeAcademyNET8.Advanced___OOP.Classes.Inheritance_and_Virtual;

public class Transport
{
    public int Speed { get; set; }

    public virtual string MeasureSpeed() => $"Transport speed is {Speed} km/h";
}