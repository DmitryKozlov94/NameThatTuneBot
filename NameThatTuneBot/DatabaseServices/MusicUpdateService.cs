using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NameThatTuneBot.DatabaseServices.Entites;
using NameThatTuneBot.DatabaseServices.Commands;
using System.Threading.Tasks;

namespace NameThatTuneBot.DatabaseServices
{
    class MusicUpdateService
    {
         private Mediator mediator;

        public MusicUpdateService(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task AddNewTracks(string artist, string fileLocation, string trackName = "")
        {
            Console.WriteLine("1");
            MusicInfo newTrack = new MusicInfo(artist, fileLocation, trackName);
            Console.WriteLine("2");
            await mediator.HandleCommand(new AddItem(newTrack));
            Console.WriteLine("3");
            Console.WriteLine("Add new track - {0} -- {1}", artist, trackName);
        }
       
    }
}
