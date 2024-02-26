namespace SupportBank.BankManagement;

public class Transaction
{
    public required decimal Amount {get; init;}

    public required string Narrative {get; init;} = string.Empty;

    public required Account From {get; init;}

    public  required Account To {get; init;}

    public required string Date {get; init;}
}
