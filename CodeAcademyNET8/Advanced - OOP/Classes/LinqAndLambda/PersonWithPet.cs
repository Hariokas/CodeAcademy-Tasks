namespace CodeAcademyNET8.Advanced___OOP.Classes.LinqAndLambda;

internal class PersonWithPet(string name, List<Pet> petList)
{
    private string Name { get; } = name;
    internal List<Pet> PetList { get; set; } = petList;

    public override string ToString()
    {
        return $"{Name} has {PetList.Count} pets: {PetList.Select(x => x.ToString()).ToList()}";
    }
}