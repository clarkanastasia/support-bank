namespace SupportBank.BankManagement;

public class Transaction
{
    public int Amount {get; init;}
    public string Narrative {get; init;} = string.Empty;

    public Account From {get; init;}

    public Account To {get; init;}

    public string Date {get; init;}
}
