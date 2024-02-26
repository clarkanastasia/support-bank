namespace SupportBank.BankManagement;

public class Bank
{
    public string BankName {get; init;} = string.Empty;

    public readonly HashSet<Account> _accounts = [];

    public readonly HashSet<Transaction> _transactions = [];

    public void AddAccount(string name)
    {
        var newAccount = new Account 
        {
            AccountHolder = name,
            Bank = this,
        };
        _accounts.Add(newAccount);
    }
    
    public void GetAccounts()
    {
        Console.WriteLine($"Here is a list of all the account holders at: {BankName}:");
        foreach (Account account in _accounts)
        {
            Console.WriteLine(account.AccountHolder);
        }
    }

    public Account FindAccount(string name)
    {
        var accountToFind = new Account
        {
            AccountHolder = name,
            Bank = this,
        };
        var existingCustomer = _accounts.First(a => a.Equals(accountToFind));
        return accountToFind;
    }

    public void AddTransaction(decimal amount, string narrative, string from, string to, string date)
    {
        var newTransaction = new Transaction
        {
            Amount = amount,
            Narrative = narrative,
            From = FindAccount(from),
            To = FindAccount(to),
            Date = date
        };
    _transactions.Add(newTransaction);
    }

    public void GetTransactions()
    {
        Console.WriteLine($"Here is a list of all the transactions at {BankName}:");
        foreach (Transaction t in _transactions)
        {
            Console.WriteLine($"{t.From.AccountHolder} gave {t.To.AccountHolder} {t.Amount} for {t.Narrative} on {t.Date}");
        }
    }

    public void GetTransactionsByName(string name)
    {
        IEnumerable<Transaction> query = _transactions.Where((t) => t.From.AccountHolder == name);
        Console.WriteLine($"Here are all the transactions involving {name}: ");
        foreach (Transaction t in query)
        {
            Console.WriteLine($"{t.Amount} to {t.To.AccountHolder} for {t.Narrative} on {t.Date}");
        }   
    }
    public void GetAllTransactionsBySum()
    {
        foreach (Account account in _accounts)
        {
        IEnumerable<Transaction> query = _transactions.Where((t) => t.To.Equals(account));
            decimal totalAmount = 0;
            foreach (Transaction t in query)
            {
                totalAmount = query.Sum(t => t.Amount);
            }
        Console.WriteLine($"{account.AccountHolder} owes a total of {totalAmount}");
        }
    }
}