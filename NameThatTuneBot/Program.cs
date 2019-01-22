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
            Console.WriteLine("Add new track");
            //Console.ReadLine();
            var musicUpdate = new MusicUpdateService(mediator);
            string track = "";
            // var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = @"D:\Files\Learning\__Методы\Final\NameThatTuneBot\NameThatTuneBot\NameThatTuneBot\OggTracks\";
            Console.WriteLine(path);
            while (true)
            {
                Console.Write("Add \n Artist Name:");
                var artist = Console.ReadLine();
                Console.Write("Add \n Track Name:");
                var trackName = Console.ReadLine();
                if (artist != "" && trackName != "")
                {
                    musicUpdate.AddNewTracks(artist, path, trackName).Wait();
                }
            }
            Task.WaitAll();  
        }
    }
}
