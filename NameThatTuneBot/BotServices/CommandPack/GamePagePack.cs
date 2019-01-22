using NameThatTuneBot.DatabaseServices.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using NameThatTuneBot.BotServices.BotCommand;
using NameThatTuneBot.DatabaseServices.Commands;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

namespace NameThatTuneBot.BotServices.CommandPack
{
    public class GamePagePack:ICommandPack
    {
        public GamePagePack()
        {

        }
        public async Task HandleMessage(Message.Message message, Mediator mediator)
        {
            if("Stop the game" == message.Data)
            {
                await mediator.HandleCommand(new UpdateUserStatus(message.Id, UserStates.FirstLevel));
                await mediator.HandleCommand(new DeleteUserAnswer(message.Id));
                await mediator.HandleCommand(message);
            }
            if (Regex.IsMatch(message.Data, @"^[1-4]$", RegexOptions.Multiline))
            {
                await SendSelectionResult(message, mediator);
                await SendMusicPage(message, mediator);
            }
            if(""== message.Data)
            {
                await SendMusicPage(message, mediator);
            }
        }

        private async Task SendSelectionResult(Message.Message contex, Mediator mediator)
        {
            var correctAnswer = new CheckAnswer(contex.Id, contex.Data);
            await mediator.HandleCommand(correctAnswer);
            Console.WriteLine("_________________correctAnswer" + correctAnswer.Result);
            var text = MessageTextPattern.GetResultMessage(correctAnswer.Result);
            await mediator.HandleCommand(new SendMessageCommand(contex.Id, text));
        }
        private async Task SendMusicPage(Message.Message contex, Mediator mediator)
        {
            Console.WriteLine("1.1");
            var musicTrack = new GetMusicTrack(4);
            Console.WriteLine("1.2");
            await mediator.HandleCommand(musicTrack);
            Console.WriteLine("1.3");
            var random = new Random();
            Console.WriteLine("1.4");
            var correctAnswer = random.Next(1, 4);
           
            Console.WriteLine("1.6_" + musicTrack.MusicInfo.Length.ToString());
            //foreach(var music in musicTrack.MusicInfo)
            //{
            //    Console.WriteLine(music.atrist);
            //}
            var text = MessageTextPattern.GetSelectPage(musicTrack.MusicInfo.Select(x => x.GetNameTrack()).ToArray());
            Console.WriteLine(text);
            Console.WriteLine("1.7");
            UserAnswer userAnswer = new UserAnswer { userId = contex.Id, answer = correctAnswer.ToString() };
            Console.WriteLine("1.8");
            // await mediator.HandleCommand(new AddUserAnswer(userAnswer));
            Console.WriteLine("1.9");
            await mediator.HandleCommand(new UpdateUserAnswer(contex.Id, correctAnswer.ToString()));
            Console.WriteLine("correctAnswer" + correctAnswer.ToString());
            Console.WriteLine("correctAnswer" + musicTrack.MusicInfo.Count().ToString());
            await mediator.HandleCommand(new SendGamePageCommand(contex.Id, text, musicTrack.MusicInfo[correctAnswer-1]));
            Console.WriteLine("1.8");
        }

        private async Task SendMusicPage1(Message.Message contex, Mediator mediator)
        {
            UserAnswer userAnswer = new UserAnswer { userId = contex.Id, answer = "1" };
            await mediator.HandleCommand(new AddUserAnswer(userAnswer));
            MusicInfo musicInfo = new MusicInfo { fileLocation = @"D:\file4.ogg" };
            await mediator.HandleCommand(new SendGamePageCommand(contex.Id, "Test", musicInfo));
        }
    }
}
