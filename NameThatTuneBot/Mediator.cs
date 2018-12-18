using System;
using System.Collections.Generic;
using System.Text;
using NameThatTuneBot.DatabaseServices;
using NameThatTuneBot.TelegramServices;

namespace NameThatTuneBot
{
    class Mediator
    {
       private DatabaseOperator databaseOperator;
       private TelegramOperator telegramOperator;
       private MessageHandler messageHandler;

        public Mediator(DatabaseOperator databaseOperator, TelegramOperator telegramOperator, MessageHandler messageHandler)
        {
            this.databaseOperator = databaseOperator;
            this.telegramOperator = telegramOperator;
            this.messageHandler = messageHandler;
        }
    }
}
