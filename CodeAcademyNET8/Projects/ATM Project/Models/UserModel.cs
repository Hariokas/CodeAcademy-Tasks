namespace CodeAcademyNET8.Projects.ATM_Project.Models;

internal class UserModel
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Id { get; set; }
    public string Pin { get; set; } = "";
    public double Balance { get; set; }
    public List<TransactionModel> Transactions { get; set; } = [];
}