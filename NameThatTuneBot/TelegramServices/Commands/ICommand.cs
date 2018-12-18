using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace NameThatTuneBot.Commands
{
    public interface ICommand
    {
        void SendCommand(Message message);
    }
}
