namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal class SportsGameLeague<T> where T : SportsTeam
{
    private readonly List<T> _teams = new();

    public void AddTeam(T team)
    {
        if (_teams.Count > 0 && _teams[0].Sport != team.Sport)
        {
            Console.WriteLine($"Cannot add a team of sport {team.Sport} to a {typeof(T).Name} league");
            return;
        }

        if (_teams.Contains(team))
        {
            Console.WriteLine($"{team.Sport} team is already in the league!");
        }
        else
        {
            _teams.Add(team);
            Console.WriteLine($"{team.Sport} team added to the league.");
        }
    }

    public void PrintTeams()
    {
        foreach (var team in _teams)
            Console.WriteLine(team.ToString());
    }
}