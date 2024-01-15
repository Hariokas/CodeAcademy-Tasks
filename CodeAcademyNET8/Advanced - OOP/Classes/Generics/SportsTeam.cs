namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal abstract class SportsTeam
{
    public abstract string Sport { get; }
    public abstract string Name { get; set; }

    public override string ToString()
    {
        return $"{Sport} sports team: {Name}";
    }
}