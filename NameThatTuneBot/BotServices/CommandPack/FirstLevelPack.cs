using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using System.Linq;
using NameThatTuneBot.TelegramServices.Commands;
using NameThatTuneBot.TelegramServices;

namespace NameThatTuneBot.BotServices.CommandPack
{
    internal class FirstLevelPack : CommandPack
    {
        public FirstLevelPack(UserStates accessLevel, Dictionary<string, ICommandPack> packCommands, MessageHandler messageHandler) 
            : base(accessLevel, packCommands, messageHandler)
        {
        }

        public override async Task HandleMessage(MessageEventArgs message)
        {
            long user = message.Message.Chat.Id;
            string command = message.Message.Text.Split(' ').First();
            if (packCommands.ContainsKey(command))
            {
                await packCommands[command].Handle(message);
            }  
        }
    }
}
