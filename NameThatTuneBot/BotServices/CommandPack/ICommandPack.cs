using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using System.Linq;

namespace NameThatTuneBot.BotServices.CommandPack
{
    public interface ICommandPack
    {
        Task HandleMessage(Message.Message message, Mediator mediator);
    }
}
