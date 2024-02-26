namespace SupportBank.BankManagement;

public class Bank
{
    public string BankName {get; init;} = string.Empty;

    public readonly HashSet<Account> _accounts = [];

    public readonly HashSet<Transaction> Transactions = [];

    public void AddAccount(string name)
    {
        var newAccount = new Account 
        {
            AccountHolder = name,
        };
        _accounts.Add(newAccount);
    }
    
    public void GetAccounts()
    {
        Console.WriteLine($"Here is a list of all the account holders at: ${BankName}:");
        foreach (Account account in _accounts)
        {
            Console.WriteLine(account.AccountHolder);
        }
    }
}