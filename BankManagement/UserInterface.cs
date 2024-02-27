namespace SupportBank.BankManagement;
using NLog;

public class UserInterface
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public Bank Bank {get; init;}
    public void Run()
    {
    Logger.Info("App has started running");
    ReadFile();
    DisplayMenu();
    }

    public void DisplayMenu()
    {
    Console.WriteLine($"Welcome to {Bank.BankName}!");
    Logger.Info("User has started using the menu");
    bool isFinished;
    do
    {
        Console.WriteLine("Please select an option from the list below: \n 1. See all transactions\n 2. See how much each person owes\n 3. Find transactions for particular person\n 4. Exit programme");
        var input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "1":
                    Bank.GetTransactions();
                    break;
                case "2":
                    Bank.GetAllTransactionsBySum();
                    break;
                case "3":
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
    Logger.Info("User has finished using the menu");    
    } 

    public void ReadFile()
    {
        string fileName = GetFileName();
        ReadAccounts(fileName);
        ReadTransactions(fileName);
        Console.WriteLine("Finished reading file");
    }

    public static string GetFileName()
    {
        // Console.WriteLine("Please enter the file you would like to read");
        // var fileName = Console.ReadLine() ?? "";
        // string fileName = "Transactions2014.csv";
        string fileName = "DodgyTransactions2015.csv";
        Logger.Info($"The selected file is {fileName}");

        return fileName;
    } 

    public void ReadAccounts(string fileName)
    {
        bool isFirstLine = true;
        try
        {
            var reader = new StreamReader(fileName);
            string line; 
            while ((line = reader.ReadLine()) != null)
            {
                if (isFirstLine){
                    isFirstLine = false;
                    continue;
                }
                    string[] parts = line.Split(",");
                    Bank.AddAccount(parts[1]);
                    Bank.AddAccount(parts[2]);
            }
        Logger.Info("Finished getting account names from file");    
        reader.Close();    
        }
        catch (Exception ex)
        {
            Logger.Warn($"Failed to create Account instance: {ex.Message}");
        }
    }

    public void ReadTransactions(string fileName)
    {
        bool isFirstLine = true;
        try
        {
            var reader = new StreamReader(fileName);
            string line; 
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
                    catch (Exception ex ){
                    Logger.Warn($"Failed to convert to decimal: {ex.Message}");
                    }
                    Bank.AddTransaction(amount, narrative, from, to, date);
            }
        Logger.Info("Finished getting transaction info from file");    
        reader.Close();    
        }
        catch (Exception ex)
        {
            Logger.Error($"Failed to create Transaction instance: {ex.Message}");
        }
    }
}
