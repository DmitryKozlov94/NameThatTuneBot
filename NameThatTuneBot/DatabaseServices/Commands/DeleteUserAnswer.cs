using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;
using System.Linq;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class DeleteUserAnswer : ICommand<ApplicationContext>
    {
        public DeleteUserAnswer(long userId)
        {
            this.userId = userId;
        }
        public async Task HandleCommand(ApplicationContext contex)
        {
            UserAnswer[] users = contex.UserAnswer.Where(user => user.userId == userId).ToArray();
            contex.UserAnswer.RemoveRange(users);
            await contex.SaveChangesAsync();
        }

        private long userId;
    }
}
