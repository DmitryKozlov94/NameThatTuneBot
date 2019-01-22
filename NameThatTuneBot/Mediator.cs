using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices;
using NameThatTuneBot.DatabaseServices.Commands;
using NameThatTuneBot.TelegramServices;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace NameThatTuneBot
{
    public class Mediator
    {
       private DatabaseOperator databaseOperator;
       private IBotServices telegramOperator;
       private MessageHandler messageHandler;
    

        public Mediator(DatabaseOperator databaseOperator, IBotServices telegramOperator, MessageHandler messageHandler)
        {
            this.databaseOperator = databaseOperator;
            this.telegramOperator = telegramOperator;
            this.telegramOperator.AddMediator(this);
            this.messageHandler = messageHandler;
            this.messageHandler.AddMediator(this);
        }

        public async Task HandleCommand(ICommand<ApplicationContext> command)
        {
            await databaseOperator.HandleAsync(command);
        }
        public async Task HandleCommand(ICommand<ApiBot> command)
        {
            await telegramOperator.HandleAsync(command);
        }
        public async Task HandleCommand(Message.Message message)
        {
            await messageHandler.HandleMessage(message);
        }

        
    }
}
