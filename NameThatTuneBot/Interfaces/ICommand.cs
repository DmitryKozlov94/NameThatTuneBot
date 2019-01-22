using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameThatTuneBot
{
    public interface ICommand<T>
    {
        Task HandleCommand(T contex);
    }
}
