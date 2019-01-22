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
        public async Task HandleCommand(ApplicationContext contex)
        {
            Console.WriteLine("START_1"+contex.MusicInfos.Count());
            Console.WriteLine(contex.MusicLength);
            
            Random random = new Random();
            Console.WriteLine("START_!!!" );
            //for (int i=0; i<numberOfTracks ; i++)
            //{
            //    Console.WriteLine("START_"+i);
            //    MusicInfo[i] = await contex.MusicInfos.FindAsync(random.Next(1, contex.MusicLength));
            //}
            this.MusicInfo = contex.MusicInfos.OrderBy(x => random.Next()).Take(numberOfTracks).ToArray();
        }

        private int numberOfTracks;
        public MusicInfo[] MusicInfo { get; private set; }
    }
}
