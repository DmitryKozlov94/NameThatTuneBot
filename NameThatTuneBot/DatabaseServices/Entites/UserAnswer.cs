using System;
using System.Collections.Generic;
using System.Text;

namespace NameThatTuneBot.DatabaseServices.Entites
{
    public class UserAnswer
    {
        public int Id {get; set;}
        public long userId { get; set; }
        public string answer { get; set; }
    }
}
