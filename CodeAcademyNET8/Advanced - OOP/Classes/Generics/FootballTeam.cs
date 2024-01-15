namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal class FootballTeam(string name) : SportsTeam
{
    public override string Sport => "Football";
    public override string Name { get; set; } = name;
}