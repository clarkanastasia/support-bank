using SupportBank.BankManagement;

var myBank = new Bank
{
    BankName = "myBank"
};

var menu = new UserInterface
{
    Bank = myBank
};

menu.ReadFile();

myBank.GetAccounts();
myBank.GetTransactions();