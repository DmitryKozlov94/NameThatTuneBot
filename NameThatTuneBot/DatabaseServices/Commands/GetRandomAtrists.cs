using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NameThatTuneBot.DatabaseServices.Entites;
using System.Linq;
using NameThatTuneBot.Expansion;
using Microsoft.EntityFrameworkCore;


namespace NameThatTuneBot.DatabaseServices.Commands
{
    class GetRandomArtists : ICommand<ApplicationContext>
    {
        public GetRandomArtists(string notUseArtist, int numArtist)
        {
            this.notUseArtist = notUseArtist;
            this.numArtist = numArtist;
        }
        public Task HandleCommand(ApplicationContext contex)
        {
            artistNames = new string[numArtist];
            var artists = contex.MusicInfos.Include(music => music.atrist)
                                             .Where(music => music.atrist != notUseArtist);
            for (int i = 0; i<numArtist; i++)
            {
                 artistNames[i] = artists.Random().atrist;
            }
            return null; //Исправить
        }

        public string[] GetArtists()
        {
            return artistNames;
        }
        private int numArtist;
        private string[] artistNames;
        private string notUseArtist;
    }
}
