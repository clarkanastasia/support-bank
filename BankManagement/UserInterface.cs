using Microsoft.Extensions.Logging;

namespace SupportBank.BankManagement;

public class UserInterface
{
    private readonly ILogger<UserInterface> _logger;
    public Bank? Bank {get; set;} 

    public UserInterface(ILogger<UserInterface> logger)
    {
        _logger = logger;
    }
    public void Run()
    {
    _logger.LogInformation("App has started running");
    ReadFile();
    DisplayMenu();
    }

    public void DisplayMenu()
    {
    if(Bank == null)
    {
        Console.WriteLine("No bank");
        return;
    }    
    Console.WriteLine($"Welcome to {Bank.BankName}!");
    _logger.LogInformation("User has started using the menu");
    bool isFinished;
    do
    {
        Console.WriteLine("Please select an option from the list below: \n 1. See all transactions\n 2. See how much each person owes\n 3. Find transactions for particular person\n 4. Exit programme");
        var input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "1":
                    _logger.LogInformation("User selected option 1");
                    Bank.GetTransactions();
                    break;
                case "2":
                    _logger.LogInformation("User selected option 2");
                    Bank.GetAllTransactionsBySum();
                    break;
                case "3":
                    _logger.LogInformation("User selected option 3");
                    Console.WriteLine("Enter the name of the account holder");
                    string name = Console.ReadLine() ?? "";
                    Bank.GetTransactionsByName(name);
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("The option you selected is not valid");       
                    break;
            }
            Console.WriteLine("Do you want to see the menu again? \n 1. Yes \n 2. No");
            input = Console.ReadLine() ?? "";
            isFinished = input == "2";
        } while(!isFinished);
    _logger.LogInformation("User has finished using the menu");    
    } 

    public void ReadFile()
    {
        string fileName = GetFileName();
        ReadAccounts(fileName);
        ReadTransactions(fileName);
        Console.WriteLine("Finished reading file");
    }

    public string GetFileName()
    {
        Console.WriteLine("Please enter the file you would like to read");
        var fileName = Console.ReadLine() ?? "";
        // string fileName = "Transactions2014.csv";
        // string fileName = "DodgyTransactions2015.csv";
        _logger.LogInformation("The selected file is {fileName}", fileName);

        return fileName;
    } 

    public void ReadAccounts(string fileName)
    {
        if(Bank == null)
        {
            Console.WriteLine("No bank");
            return;
        }  
        bool isFirstLine = true;
        try
        {
            var reader = new StreamReader(fileName);
            string? line; 
            while ((line = reader.ReadLine()) != null)
            {
                
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }
                    string[] parts = line.Split(",");
                    Bank.AddAccount(parts[1]);
                    Bank.AddAccount(parts[2]);
            }
        _logger.LogInformation("Finished getting account names from file");    
        reader.Close();    
        }
        catch (FileNotFoundException ex)
        {
            _logger.LogError("Couldn't find required file: {ex.Message}", ex.Message);
        }
    }

    public void ReadTransactions(string fileName)
    {
    if(Bank == null)
    {
        Console.WriteLine("No bank");
        return;
    }  
        bool isFirstLine = true;
        try
        {
            var reader = new StreamReader(fileName);
            string? line; 
            while ((line = reader.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }
                    string[] parts = line.Split(",");
                    DateTime date = default;
                    if (DateTime.TryParse(parts[0], out DateTime dateValue))
                    {
                    date = dateValue;
                    }
                    var from = parts[1];
                    var to = parts[2];
                    var narrative = parts[3];
                    decimal amount = 0;
                    try {
                    amount = Convert.ToDecimal(parts[4]);
                    } 
                    catch (FormatException ex )
                    {
                    _logger.LogWarning("Failed to convert to decimal: {ex.Message}", ex.Message);
                    }
                    Bank.AddTransaction(amount, narrative, from, to, date);
            }
        _logger.LogInformation("Finished getting transaction info from file");    
        reader.Close();    
        }
        catch (FileNotFoundException ex)
        {
            _logger.LogError("Couldn't find rrequired file: {ex.Message}", ex.Message);
        }
    }
}
