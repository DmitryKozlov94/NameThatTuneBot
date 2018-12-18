using System.Threading.Tasks;
using Telegram.Bot;

namespace NameThatTuneBot.TelegramServices
{
    internal class TelegramOperator
    {

        private TelegramBotClient client;

        public TelegramOperator(string authToken)
        {
            this.client = new TelegramBotClient(authToken);
        }

        public async Task HandleAsync(ICommand<TelegramBotClient> command)
        {
           await command.HandleCommand(client);
        }


    }
}