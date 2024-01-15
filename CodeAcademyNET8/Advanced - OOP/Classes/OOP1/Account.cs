namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Account
{
    public Account(string owner, decimal initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public string Owner { get; }
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
            Balance -= amount;
        else
            Console.WriteLine("Insufficient funds.");
    }

    public override string ToString()
    {
        return $"Account of {Owner}, Balance: {Balance}";
    }
}