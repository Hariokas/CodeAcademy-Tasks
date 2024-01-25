using CodeAcademyNET8.Projects.ATM_Project.Enums;
using CodeAcademyNET8.Projects.ATM_Project.Models;

namespace CodeAcademyNET8.Projects.ATM_Project.Services;

// Manages transactions, withdrawal limits, and history
internal class TransactionService(FileService fileService)
{
    internal static double MaxWithdrawalSumPerDay => 1000.00;
    internal static int MaxWithdrawalTimesPerDay => 10;

    internal void Deposit(UserModel currentUser)
    {
        var amount = GetAmount("Please enter the amount you want to deposit: ");
        if (amount <= 0)
        {
            Console.WriteLine("Incorrect amount.");
            return;
        }

        currentUser.Balance += amount;
        currentUser.Transactions.Add(CreateTransaction(amount, TransactionTypeEnum.Deposit));

        fileService.UpdateUser(currentUser);

        Console.WriteLine($"You have successfully deposited {amount}.");
    }

    internal void Withdraw(UserModel currentUser)
    {
        var amount = GetAmount("Please enter the amount you want to withdraw: ");

        if (amount <= 0)
        {
            Console.WriteLine("Invalid amount.");
            return;
        }

        if (amount > currentUser.Balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        if (!CanWithdraw(currentUser.Transactions, amount))
            return;

        currentUser.Balance -= amount;
        currentUser.Transactions.Add(CreateTransaction(amount, TransactionTypeEnum.Withdraw));

        fileService.UpdateUser(currentUser);

        Console.WriteLine($"You have successfully withdrawn {amount}.");
    }

    private static TransactionModel CreateTransaction(double amount, TransactionTypeEnum transactionType)
    {
        return new TransactionModel
        {
            Date = DateTime.Now,
            TransactionType = transactionType,
            Amount = amount
        };
    }

    private static bool CanWithdraw(List<TransactionModel> transactionsList, double withdrawAmount)
    {
        var timesWithdrawnToday = TimesWithdrawnToday(transactionsList);
        if (timesWithdrawnToday >= MaxWithdrawalTimesPerDay)
        {
            Console.WriteLine("You have reached the maximum withdrawal times for today.");
            return false;
        }

        var amountWithdrawnToday = AmountWithdrawnToday(transactionsList);
        if (amountWithdrawnToday + withdrawAmount > MaxWithdrawalSumPerDay)
        {
            Console.WriteLine(
                $"You are trying to exceed the withdrawal limit. The maximum you can withdraw is: {MaxWithdrawalSumPerDay - amountWithdrawnToday}");
            return false;
        }

        return true;
    }

    private static double AmountWithdrawnToday(List<TransactionModel> transactionsList)
    {
        return transactionsList
            .Where(x => x.TransactionType == TransactionTypeEnum.Withdraw && x.Date.Date == DateTime.Now.Date)
            .Sum(x => x.Amount);
    }

    private static int TimesWithdrawnToday(List<TransactionModel> transactionsList)
    {
        return transactionsList
            .Count(x => x.TransactionType == TransactionTypeEnum.Withdraw && x.Date.Date == DateTime.Now.Date);
    }

    private static double GetAmount(string message)
    {
        Console.Write(message);

        if (double.TryParse(Console.ReadLine(), out var amount))
            return amount;

        return 0;
    }

    internal void PrintTransactionHistory(UserModel currentUser)
    {
        var lastFiveTransactions = currentUser.Transactions
            .OrderByDescending(x => x.Date)
            .Take(5)
            .ToList();

        foreach (var transaction in lastFiveTransactions)
            Console.WriteLine(transaction.ToString());
    }
}