using System;
using System.Collections.Generic;
using System.Text;

namespace NameThatTuneBot.DatabaseServices.Entites
{
    public class MusicInfo: IEqualityComparer<MusicInfo>
    {
       public int Id { get; set; }
       
        public string atrist { get; set; }

        public string trackName { get; set; }

        public long fileID { get; set; }

        public string UriTrack { get; set; }

        public bool Equals(MusicInfo x, MusicInfo y)
        {
            return x.atrist == y.atrist;
        }

        public int GetHashCode(MusicInfo obj)
        {
            return obj.atrist.GetHashCode();
        }
    }
}
