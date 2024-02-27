namespace SupportBank.BankManagement;

public class Transaction
{   
    private decimal _amount;

    public required string Narrative {get; init;} = string.Empty;

    public required Account From {get; init;}
    public required Account To {get; init;}
    public required DateTime Date {get; set;}

    public required decimal Amount 
    {
        get 
        {
            return _amount;
        }
        set 
        {
            if (value > 0)
            {
                _amount = value;
            } else{
                _amount = 0;
            }
        }
    }
}
