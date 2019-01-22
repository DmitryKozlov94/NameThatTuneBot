using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot.TelegramServices
{
    public interface IBotServices
    {
        Task HandleAsync(ICommand<ApiBot> command);
        void AddMediator(Mediator mediator);
    }
}
