using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot.BotServices.BotCommand
{
    public class SendMessageCommand:ICommand<ApiBot>
    {
        public SendMessageCommand(long id, string text) //CHANGE!!!
        {
            this.text = text;
            this.id = id;
        }
        public async Task HandleCommand(ApiBot contex)
        {
            await contex.SendSimpleMessage(id, text, KeyboardTypes.None);
        }

        private long id;
        private string text;
    }
}
