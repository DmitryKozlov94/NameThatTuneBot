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
        public async Task HandleCommand(ApplicationContext contex)
        {
            var user = await contex.UserStatuses.FindAsync(userId);
            this.UserStates = (user == null) ? UserStates.None : user.state;
        }

        public UserStates UserStates{ get; private set; }
        private long userId;
    }
}
