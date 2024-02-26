namespace SupportBank.BankManagement;

public class Bank
{
    public string BankName {get; init;} = string.Empty;

    public readonly HashSet<Account> Accounts = [];

    public readonly HashSet<Transaction> Transactions = [];
}