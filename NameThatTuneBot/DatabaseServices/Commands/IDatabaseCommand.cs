using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot.DatabaseServices.Commands
{
    interface IDatabaseCommand<T>
    {
        Task HandleCommand(T contex);
    }
}
