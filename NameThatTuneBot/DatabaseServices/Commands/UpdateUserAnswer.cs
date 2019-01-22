using NameThatTuneBot.DatabaseServices.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class UpdateUserAnswer : ICommand<ApplicationContext>
    {
        public UpdateUserAnswer(long Id, string answer)
        {
            this.answer = new UserAnswer { userId = Id, answer = answer };
        }
        public async Task HandleCommand(ApplicationContext contex) //Изменить 
        {
            if (contex.UserAnswer.Any(x => x.userId == this.answer.userId))
            { 
                UserAnswer user = contex.UserAnswer.Where(x => x.userId == this.answer.userId).First();
                Console.WriteLine(user != null);
                if (user != null)
                {
                    user.answer = answer.answer;
                    await contex.SaveChangesAsync();
                }
            }else
            {
                await contex.UserAnswer.AddAsync(answer);
                await contex.SaveChangesAsync();
            }
        }

        private UserAnswer answer;
    }
}
