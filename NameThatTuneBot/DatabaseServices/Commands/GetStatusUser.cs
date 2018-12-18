using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class GetStatusUser : ICommand<ApplicationContext>
    {
        public GetStatusUser(long userId)
        {
            this.userId = userId;
        }
        public Task HandleCommand(ApplicationContext contex)
        {
            var user = contex.UserStatuses.Find(userId);
            state = (user == null) ? UserStates.None : user.state;
            return null;
        }
        public UserStates GetState()
        {
            return state;
        }
         

        private UserStates state;
        private long userId;
    }
}
