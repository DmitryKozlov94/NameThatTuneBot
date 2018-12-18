using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NameThatTuneBot.DatabaseServices.Entites
{
    public class UserStatus
    {
        public long userId { get; set; }
        public UserStates state { get; set; }
    }

    
}