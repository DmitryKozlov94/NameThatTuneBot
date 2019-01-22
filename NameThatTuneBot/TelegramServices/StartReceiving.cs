using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.TelegramServices;

namespace NameThatTuneBot.TelegramServices
{
    public class StartReceiving : ICommand<ApiBot>
    {
        public Task HandleCommand(ApiBot contex)
        {
            contex.StartReceiving();
            return Task.FromResult<object>(null);
        }
    }
}
