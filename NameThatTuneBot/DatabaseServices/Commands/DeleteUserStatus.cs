using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;
using System.Linq;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class DeleteUserStatus : IDatabaseCommand<ApplicationContext>
    {
        public DeleteUserStatus(long userId)
        {
            this.userId = userId;
        }
        public async Task HandleCommand(ApplicationContext contex)
        {
            UserStatus user = contex.UserStatuses.Find(userId);
            contex.UserStatuses.Remove(user);
            await contex.SaveChangesAsync();
        }

        private long userId;
    
    }
}
