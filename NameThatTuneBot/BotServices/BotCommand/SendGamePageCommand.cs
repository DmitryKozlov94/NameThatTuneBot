using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;

namespace NameThatTuneBot.BotServices.BotCommand
{
    public class SendGamePageCommand : ICommand<ApiBot>
    {
        public SendGamePageCommand(long id, string text, MusicInfo musicInfo) //CHANGE!!!
        {
            this.musicInfo = musicInfo;
            Console.WriteLine("AAA ="+ musicInfo.atrist);
            this.text = text;
            Console.WriteLine("AAA =" + text);
            this.id = id;
            Console.WriteLine("AAA =" + id.ToString());
        }

        public async Task HandleCommand(ApiBot contex)
        {
            await contex.SendMusicMessage(id, text, musicInfo, KeyboardTypes.KeyboardSelection);
        }

        private long id;
        private string text;
        private MusicInfo musicInfo;
    }
}
