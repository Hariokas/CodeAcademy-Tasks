namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Address
{
    public Address(string city, string street)
    {
        City = city;
        Street = street;
    }

    public string City { get; set; }
    public string Street { get; set; }

    public override string ToString()
    {
        return $"Street: {Street}, City: {City}";
    }
}