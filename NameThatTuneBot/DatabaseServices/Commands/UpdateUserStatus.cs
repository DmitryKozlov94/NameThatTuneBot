using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class UpdateUserStatus : ICommand<ApplicationContext>
    {
        public UpdateUserStatus(long Id, UserStates userState)
        {
            userStatus = new UserStatus { userId = Id, state = userState };
            IsExseption = false;
        }
        public async Task HandleCommand(ApplicationContext contex)
        {
            try
            {
                UserStatus user = await contex.UserStatuses.FindAsync(userStatus.userId);
                //Возможно бессмысленно
                Console.WriteLine("_____________UpdateUserStatus___" + user.state);
                if (user != null || user.state != userStatus.state)
                {
                    user.state = userStatus.state;

                    await contex.SaveChangesAsync();
                }
            }
            catch
            {
                IsExseption = true;
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!1Duplication");
            }
        }
        public bool IsExseption { get; private set; }
        private UserStatus userStatus;
    }
}
