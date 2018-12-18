using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using System.Linq;

namespace NameThatTuneBot.BotServices.CommandPack
{
    abstract class CommandPack
    {
        protected UserStates accessLevel;
        protected Dictionary<string, ICommandPack> packCommands;
        protected MessageHandler messageHandler;

        public CommandPack(UserStates accessLevel, Dictionary<string, ICommandPack> packCommands, MessageHandler messageHandler)
        {
            this.accessLevel = accessLevel;
            this.packCommands = packCommands;
            this.messageHandler = messageHandler;
        }

        public void AddCommand(string commandName, ICommandPack command)
        {
            this.packCommands.Add(commandName, command);
        }

        public abstract Task HandleMessage(MessageEventArgs message);
    }
}
