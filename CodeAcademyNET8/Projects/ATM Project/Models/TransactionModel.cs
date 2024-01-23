using CodeAcademyNET8.Projects.ATM_Project.Enums;

namespace CodeAcademyNET8.Projects.ATM_Project.Models;

internal class TransactionModel
{
    public DateTime Date { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public double Amount { get; set; }

    public override string ToString()
    {
        return $"{Date} - {TransactionType} - {Amount}";
    }
}