using System;
using System.Linq;
using NameThatTuneBot.DatabaseServices;
using NameThatTuneBot.TelegramServices;
using NameThatTuneBot.BotServices.CommandPack;
using System.Threading.Tasks;
using System.IO;

namespace NameThatTuneBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramOperator telegramOperator = new TelegramOperator("797693271:AAF2UPE8UHv9cZiBBNOm2RZa9-gPZoJmgtM");
            MessageHandler messageHandler = new MessageHandler();
            messageHandler.AddCommandPack(UserStates.FirstLevel, new MainPagePack());
            messageHandler.AddCommandPack(UserStates.SecondLevel, new GamePagePack());
            DatabaseOperator databaseOperator = new DatabaseOperator();
            Mediator mediator = new Mediator(databaseOperator, telegramOperator, messageHandler);
            var i1 = mediator.HandleCommand(new Class1());
            
            Console.ReadLine();
       
            Task.WaitAll();  
        }
    }
}
