using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Linq;
using NameThatTuneBot.BotServices.CommandPack;
using NameThatTuneBot.DatabaseServices.Commands;

namespace NameThatTuneBot
{
    class MessageHandler
    {
        private FirstLevelPack firstPack;
        private Mediator mediator;
        public MessageHandler(FirstLevelPack firstLevelPack)
        {
            firstPack = firstLevelPack;
        }

        public void AddMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task HandleMessage(MessageEventArgs message)
        {
            var userId = message.Message.Chat.Id;
            var cmd = new GetStatusUser(userId);
            await mediator.HandleCommand( cmd);
            cmd.GetState();
        }   
    }
}
