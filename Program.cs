using SupportBank.BankManagement;
using NLog;
using NLog.Config;
using NLog.Targets;

var config = new LoggingConfiguration();
var target = new FileTarget { FileName = "${currentdir}/logfile.txt", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
LogManager.Configuration = config;

var myBank = new Bank
{
    BankName = "Support Bank"
};

var menu = new UserInterface
{
    Bank = myBank
};

menu.Run();