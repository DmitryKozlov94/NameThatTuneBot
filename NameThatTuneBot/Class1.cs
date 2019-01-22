using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.TelegramServices;

namespace NameThatTuneBot
{
    class Class1 : ICommand<ApiBot>
    {
        public Task HandleCommand(ApiBot contex)
        {
            contex.StartReceiving();
            return null;
        }
    }
}
