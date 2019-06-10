using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
