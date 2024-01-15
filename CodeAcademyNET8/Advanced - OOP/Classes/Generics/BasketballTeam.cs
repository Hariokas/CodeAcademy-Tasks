namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal class BasketballTeam(string name) : SportsTeam
{
    public override string Sport => "Basketball";
    public override string Name { get; set; } = name;
}