using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class UpdateUserStatus : IDatabaseCommand<ApplicationContext>
    {
        public UpdateUserStatus(long Id, UserState userState)
        {
            userStatus = new UserStatus { userId = Id, state = userState };
        }
        public async Task HandleCommand(ApplicationContext contex)
        {
            UserStatus user =  contex.UserStatuses.FindAsync(userStatus.userId).Result; //Возможно бессмысленно
            if (user != null)
            {
                user.state = userStatus.state;
                await contex.SaveChangesAsync();
            }
        }

        private UserStatus userStatus;
    }
}
