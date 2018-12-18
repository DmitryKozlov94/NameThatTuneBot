using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices;
using NameThatTuneBot.DatabaseServices.Commands;
using NameThatTuneBot.TelegramServices;

namespace NameThatTuneBot
{
    class Mediator
    {
       private DatabaseOperator databaseOperator;
       private TelegramOperator telegramOperator;
       private MessageHandler messageHandler;
        private ApplicationContext applicationContext;

        public Mediator(DatabaseOperator databaseOperator, TelegramOperator telegramOperator, MessageHandler messageHandler)
        {
            this.databaseOperator = databaseOperator;
            this.telegramOperator = telegramOperator;
            this.messageHandler = messageHandler;
        }

        public async Task HandleCommand(ICommand<ApplicationContext> command)
        {
            await command.HandleCommand(applicationContext);
        }

    

        public async Task HandleCommand(ICommand<TelegramOperator> command)
        {
            await command.HandleCommand(telegramOperator);
        }
        public async Task HandleCommand(ICommand<MessageHandler> command)
        {
            await command.HandleCommand(messageHandler);
        }
    }
}
