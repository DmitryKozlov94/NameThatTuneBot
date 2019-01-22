using System.Threading.Tasks;
using Telegram.Bot;

namespace NameThatTuneBot.TelegramServices
{
    public class TelegramOperator : IBotServices//НА УДАЛЕНИЕ 
    {
        string authToken;
        private TelegramService client;

        public TelegramOperator(string authToken)
        {
            this.authToken = authToken;
        }
        
        public void AddMediator(Mediator mediator)
        {
            this.client = new TelegramService(authToken, mediator);
        }

        public async Task HandleAsync(ICommand<ApiBot> command)
        {
           await command.HandleCommand(client);
        }


    }
}