using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace NameThatTuneBot.TelegramServices
{
    class TelegramService
    {
        private Func<MessageEventArgs, Task> reciveMessage;
        private Func<CallbackQueryEventArgs, Task> reciveCallbackQuery;
        public TelegramService(string authToken, Func<MessageEventArgs, Task> reciveMessage, Func<CallbackQueryEventArgs, Task> reciveCallbackQuery)
        {
            client = new TelegramBotClient(authToken);
            this.reciveMessage = reciveMessage;
            this.reciveCallbackQuery = reciveCallbackQuery;
            client.OnMessage += BotOnMessageReceived;
            client.OnCallbackQuery += BotOnCallbackQueryReceived;
            client.OnReceiveError += BotOnReceiveError;
        }

        private void BotOnReceiveError(object sender, ReceiveErrorEventArgs e)
        {
            
        }

        private void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            reciveCallbackQuery(e);
        }

        private void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            reciveMessage(e);
        }

        public  void SendMessage()
        {
           // client.SendTextMessage();
        }

        private TelegramBotClient client;
    }
}
