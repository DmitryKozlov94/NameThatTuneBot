﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NameThatTuneBot
{
    interface IContainer<T>
    {
        T GetMessage();
    }
}
