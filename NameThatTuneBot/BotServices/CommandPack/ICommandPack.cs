using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace NameThatTuneBot.BotServices.CommandPack
{
    public interface ICommandPack
    {
        Task Handle(MessageEventArgs message);
    }
}
