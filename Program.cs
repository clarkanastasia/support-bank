using SupportBank.BankManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

var servicesProvider = new ServiceCollection()
    .AddTransient<UserInterface>()
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddNLog();
    })
    .BuildServiceProvider();

var myBank = new Bank
{
    BankName = "Support Bank"
};

var menu = servicesProvider.GetRequiredService<UserInterface>();

menu.Run();