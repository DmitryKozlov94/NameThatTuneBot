using System;
using System.Collections.Generic;
using System.Text;

namespace NameThatTuneBot
{
    interface ITelegramAPI
    {
        Func<bool> getMessage();
        bool SendMessages();
        bool UpdateMessage();
    }
}
