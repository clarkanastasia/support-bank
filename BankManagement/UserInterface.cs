namespace SupportBank.BankManagement;

public class UserInterface
{
    public Bank Bank {get; init;}
    public void Run()
    {
    ReadFile();
    DisplayMenu();
    }

    public void DisplayMenu()
    {
    Console.WriteLine($"Welcome to {Bank.BankName}!");
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
                    isFinished = true;
                    break;
                default:
                    Console.WriteLine("The option you selected is not valid");       
                    break;
            }
            Console.WriteLine("Do you want to see the menu again? \n 1. Yes \n 2. No");
            input = Console.ReadLine() ?? "";
            isFinished = input == "2";
        }while(!isFinished);
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
        string fileName = "Transactions2014.csv";
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
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Sorry, that file was not found.");
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
                if (isFirstLine){
                    isFirstLine = false;
                    continue;
                }
                    string[] parts = line.Split(",");
                    var date = parts[0];
                    var from = parts[1];
                    var to = parts[2];
                    var narrative = parts[3];
                    var amount = Convert.ToDecimal(parts[4]);
                    Bank.AddTransaction(amount, narrative, from, to, date);
                    
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Sorry, that file was not found.");
        }
    }
}
