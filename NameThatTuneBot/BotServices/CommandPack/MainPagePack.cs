using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.Message;
using NameThatTuneBot.TelegramServices;
using NameThatTuneBot.BotServices.BotCommand;
using NameThatTuneBot.DatabaseServices.Commands;

namespace NameThatTuneBot.BotServices.CommandPack
{
    class MainPagePack:ICommandPack
    {
        public MainPagePack()
        {

        }
        public async Task HandleMessage(Message.Message contex, Mediator mediator)
        {
            if(contex.Data == "Run Game")
            {
                var userStatus = new UpdateUserStatus(contex.Id, UserStates.SecondLevel);
                await mediator.HandleCommand(userStatus);
                if (!userStatus.IsExseption)
                {
                    contex.Data = "";
                    await mediator.HandleCommand(contex);
                }
            }
            else
            {
               await mediator.HandleCommand(new SendMainPageCommand(contex));
            }
           
        }
    }
}
