using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot.DatabaseService
{
    interface IDatabaseCommand<T>
    {
        Task HandleCommand(T contex);
    }
}
