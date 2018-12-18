using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NameThatTuneBot.DatabaseService.Entites
{
    public class UserStatus
    {
        public int userId { get; set; }
        public string status { get; set; }
    }
}