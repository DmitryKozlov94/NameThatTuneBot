using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace NameThatTuneBot.TelegramServices.Commands
{
    class SendMessage : ICommand<TelegramBotClient>
    { 
        public SendMessage(MessageEventArgs message, ReplyKeyboardMarkup keyboardMarkup)
        {
            this.message = message;
            this.keyboardMarkup = keyboardMarkup;
        }
        public async Task HandleCommand(TelegramBotClient contex)
        {
            await contex.SendTextMessageAsync(message.Message.Chat.Id, message.Message.Text, replyMarkup: keyboardMarkup);
        }

        private MessageEventArgs message;
        private ReplyKeyboardMarkup keyboardMarkup;
    }
}
