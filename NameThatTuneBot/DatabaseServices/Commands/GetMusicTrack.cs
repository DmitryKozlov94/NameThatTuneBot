using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    class GetMusicTrack : ICommand<ApplicationContext>
    {
        public GetMusicTrack(int numberOfTrack)
        {
            Console.WriteLine("START");
            this.numberOfTracks = numberOfTrack;
            MusicInfo = new MusicInfo[numberOfTracks];
        }
        public Task HandleCommand(ApplicationContext contex)
        {
            Random random = new Random();
            this.MusicInfo = contex.MusicInfos.OrderBy(x => random.Next()).Take(numberOfTracks).ToArray();
            return Task.FromResult<object>(null);
        }

        private int numberOfTracks;
        public MusicInfo[] MusicInfo { get; private set; }
    }
}
