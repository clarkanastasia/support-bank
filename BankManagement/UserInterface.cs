using System.Collections.ObjectModel;

namespace SupportBank.BankManagement;

public class UserInterface
{
    public Bank Bank {get; init;}

    public void ReadFile(){
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
