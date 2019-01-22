using NameThatTuneBot;
using NameThatTuneBot.Message;
using NameThatTuneBot.TelegramServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BotTest
{
    class DummyBot : IBotServices
    {
        public List<ICommand<ApiBot>> messages;
        public void AddMediator(Mediator mediator)
        {
            messages = new List<ICommand<ApiBot>>();
        }

        public Task HandleAsync(ICommand<ApiBot> command)
        {
            messages.Add(command);
            return Task.FromResult<object>(null);
        }
    }
}
