using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameThatTuneBot;
using NameThatTuneBot.TelegramServices;
using System.Linq;
using NameThatTuneBot.DatabaseServices;
using NameThatTuneBot.BotServices.CommandPack;
using NameThatTuneBot.BotServices.BotCommand;
using System.Threading.Tasks;
using System.IO;

namespace BotTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HandleMessageTest()
        {
            DummyBot dummyBot = new DummyBot();
            MessageHandler messageHandler = new MessageHandler();
            messageHandler.AddCommandPack(UserStates.FirstLevel, new MainPagePack());
            messageHandler.AddCommandPack(UserStates.SecondLevel, new GamePagePack());
            DatabaseOperator databaseOperator = new DatabaseOperator();
            Mediator mediator = new Mediator(databaseOperator, dummyBot, messageHandler);
            mediator.HandleCommand(new StartReceiving()).Wait();
            var message = new NameThatTuneBot.Message.Message("Start Game", 1234567);
            mediator.HandleCommand(message).Wait();
            var result = new SendMainPageCommand(message);
            Assert.AreEqual(result.GetType(), dummyBot.messages.Last().GetType());
        }
    }
}
