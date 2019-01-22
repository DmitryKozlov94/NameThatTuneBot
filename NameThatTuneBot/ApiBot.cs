using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;


namespace NameThatTuneBot
{
    public abstract class ApiBot
    {
        protected Mediator mediator;
        public abstract void StartReceiving();

        public abstract void StopReceiving();
        public abstract Task SendSimpleMessage(long id, string text, KeyboardTypes keyboardType);
        public abstract Task SendMusicMessage(long id, string text, MusicInfo musicInfo, KeyboardTypes keyboardType);

        public ApiBot(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
