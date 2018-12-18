using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;
using System.Linq;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class CheckAnswer : ICommand<ApplicationContext>
    {
        public CheckAnswer(long userId, string answer)
        {
            this.userId = userId;
            this.answer = answer;
        }
        public Task HandleCommand(ApplicationContext contex)
        {
            var correctAnswer = contex.UserAnswer.Where(x => x.userId == userId).FirstOrDefault().answer;
            result = answer == correctAnswer;

            return null;
        }

        public bool GetResult()
        {
            return result;
        }
        private bool result;
        private string answer;
        private long userId;
    
        
    }
}
