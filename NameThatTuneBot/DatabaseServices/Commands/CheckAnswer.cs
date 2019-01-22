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
            this.UserId = userId;
            this.Answer = answer;
        }
        public Task HandleCommand(ApplicationContext contex)
        {
            if (contex.UserAnswer.Any(x => x.userId == this.UserId))
            {
                var correctAnswer = contex.UserAnswer.Where(x => x.userId == UserId).FirstOrDefault();
                Result = Answer == correctAnswer.answer;
                Answer = correctAnswer.answer;
                Console.WriteLine("_______________________________________________END");
            }
            return Task.FromResult<object>(null);
        }

        public bool Result { get; private set; }
        public string Answer { get; private set; }
        private long UserId { get; set; }
    }
}
