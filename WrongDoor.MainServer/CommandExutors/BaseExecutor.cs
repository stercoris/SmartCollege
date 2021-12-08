using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Command = WrongDoor.Connecter.GetCommandsGQL.Response.CommandSelection;

namespace WrongDoor.MainServer.CommandExutors
{
    internal interface BaseExecutor
    {
        Task<string> Execute(Command command);
    }
}
