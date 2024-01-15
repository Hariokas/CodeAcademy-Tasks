namespace CodeAcademyNET8.Advanced___OOP.Classes.OOP1;

internal class Bank
{
    private readonly List<Account> _accounts = new();

    public Account OpenAccount(string owner, decimal initialBalance)
    {
        var newAccount = new Account(owner, initialBalance);
        _accounts.Add(newAccount);
        return newAccount;
    }

    public void PrintAccounts()
    {
        foreach (var account in _accounts) Console.WriteLine(account);
    }
}