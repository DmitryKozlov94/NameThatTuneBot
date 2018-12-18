using System;
using System.Collections.Generic;
using System.Text;

namespace NameThatTuneBot.TelegramServices
{
    interface ITelegramSender
    {
        bool SendMessage();
    }
}
