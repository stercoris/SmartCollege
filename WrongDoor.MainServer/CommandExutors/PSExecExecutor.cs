using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrongDoor.Connecter;

namespace WrongDoor.MainServer.CommandExutors
{
    class PSExecExecutor : BaseExecutor
    {
        public async Task<string> Execute(GetCommandsGQL.Response.CommandSelection command)
        {
            return($"New PowerShell Command {command.body}");
        }
    }
}
