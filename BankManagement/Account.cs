namespace SupportBank.BankManagement;

public class Account
{
    public string AccountHolder {get; set;} = string.Empty;
    
    public override bool Equals(object? obj)
    {
        return obj is Account account && account.AccountHolder == AccountHolder;
    }
    
    public override int GetHashCode()
    {
        return AccountHolder.GetHashCode();
    }
}