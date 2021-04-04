using System.Diagnostics;

namespace SmartCollege.Executor.Commands
{
    class CMDCommand
    {
        public static string Execute(string command)
        {
            return ("Исполнена команда CMD: " + command);
            string outp;
            ProcessStartInfo process_options = new ProcessStartInfo(@"cmd.exe", @"/C " + command);

            // скрываем окно запущенного процесса
            process_options.WindowStyle = ProcessWindowStyle.Hidden;
            process_options.RedirectStandardOutput = true;
            process_options.RedirectStandardError = true;
            process_options.UseShellExecute = false;
            process_options.CreateNoWindow = true;

            // запускаем процесс
            Process process = Process.Start(process_options);

            // получаем ответ запущенного процесса
            outp = process.StandardError.ReadToEnd();
            outp = outp + process.StandardOutput.ReadToEnd();

            // закрываем процесс
            process.WaitForExit();

            // выводим результат
            return (outp);
        }
    }
}
