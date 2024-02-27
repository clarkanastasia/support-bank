namespace SupportBank.BankManagement;

public class Account
{
    public required string AccountHolder {get; set;}
    
    public required Bank Bank {get; init;}
    
    public override bool Equals(object? obj)
    {
        return obj is Account account && account.AccountHolder == AccountHolder;
    }

    public override int GetHashCode()
    {
        return AccountHolder.GetHashCode();
    }
}