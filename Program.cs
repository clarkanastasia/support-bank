using SupportBank.BankManagement;

var myTransactions = new List<string>();

string fileName = "";
try
{
    var reader = new StreamReader(fileName);
    // Console.WriteLine("Here is the content of your file:");
    // Console.WriteLine(reader.ReadToEnd().Trim());
    string line; 

    while ((line = reader.ReadLine().Trim()) != null)
    {
        myTransactions.Add(line);
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine("Sorry, that file was not found.");
}