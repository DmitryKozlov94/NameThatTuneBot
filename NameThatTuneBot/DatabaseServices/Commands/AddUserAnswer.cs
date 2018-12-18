using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class AddUserAnswer : ICommand<ApplicationContext>
    {
        public AddUserAnswer(UserAnswer userAnswer)
        {
            this.userAnswer = userAnswer;
        }
        public async Task HandleCommand(ApplicationContext contex)
        {
            await contex.UserAnswer.AddAsync(userAnswer);
            await contex.SaveChangesAsync();
        }

        private UserAnswer userAnswer;
    }
}
