using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot.BotServices.BotCommand
{
    public class SendMainPageCommand : ICommand<ApiBot>
    {
        public SendMainPageCommand(Message.Message message) //CHANGE!!!
        {
            this.message = message;
        }
        public async Task HandleCommand(ApiBot contex)
        {
           await contex.SendSimpleMessage(message.Id, MessageTextPattern.GetMainPage(), KeyboardTypes.MainKeyboard);
        }

        private Message.Message message;
    }
}
