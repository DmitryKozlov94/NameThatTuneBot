using System;
using System.Collections.Generic;
using System.Text;

namespace NameThatTuneBot.DatabaseService.Entites
{
    public class MusicInfo
    {
       public int ID { get; set; }
       
        public string atrist { get; set; }

        public string trackName { get; set; }

        public int fileID { get; set; }

        public string UriTrack { get; set; }
    }
}
