using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Linq;

namespace NameThatTuneBot
{
    class MessageHandler
    {
        //public async Task HandleAsync(ICommand<> command)
        //{
        //    await command.HandleCommand(client);
        //}


        public async Task HandleMessage(MessageEventArgs container)
        {
            var message = container.Message;
            message.Chat.Id;
            message.Text.Split(' ').First();
        }
    }
}
