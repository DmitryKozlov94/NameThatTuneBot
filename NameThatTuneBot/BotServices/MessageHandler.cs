using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Linq;
using NameThatTuneBot.BotServices.CommandPack;
using NameThatTuneBot.DatabaseServices.Commands;
using NameThatTuneBot.DatabaseServices.Entites;
using NameThatTuneBot.BotServices.BotCommand;

namespace NameThatTuneBot
{
    public class MessageHandler
    {
        private Dictionary<UserStates, ICommandPack> commandPack;
        private Mediator mediator;
        public MessageHandler(Dictionary<UserStates, ICommandPack> commandPack)
        {
            this.commandPack = commandPack;
        }
        public MessageHandler()
        {
            this.commandPack = new Dictionary<UserStates, ICommandPack>();
        }

        public void AddCommandPack(UserStates userStates, ICommandPack commandPack)
        {
            this.commandPack.Add(userStates, commandPack);
        }

        public void AddMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task HandleMessage(Message.Message message)
        {
            var cmd = new GetStatusUser(message.Id);
            await mediator.HandleCommand(cmd);
            Console.WriteLine(message.Id.ToString() + "___" + message.Data + "___" + cmd.UserStates.ToString());
            if (cmd.UserStates == UserStates.None)
            {
                UserStatus userStatus = new UserStatus { state = UserStates.FirstLevel, userId = message.Id };
                await mediator.HandleCommand(new AddItem(userStatus));
            }
            if (cmd.UserStates == UserStates.NewUser|| cmd.UserStates == UserStates.None)
            {
                await mediator.HandleCommand(new UpdateUserStatus(message.Id, UserStates.FirstLevel));
                await mediator.HandleCommand(message);
            }
            if (commandPack.ContainsKey(cmd.UserStates))
            {
               await commandPack[cmd.UserStates].HandleMessage(message, mediator);
            }
            
        }
          
            
         
    }
}
