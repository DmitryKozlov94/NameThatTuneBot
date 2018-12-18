using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot
{
    interface ICommand<T>
    {
        Task HandleCommand(T contex);
    }
}
