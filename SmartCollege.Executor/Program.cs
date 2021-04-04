using System;
using System.Threading.Tasks;
using SmartCollege.Executor.Commands;
using SmartCollege.Connecter;
using CommandType = SmartCollege.Connecter.API.CommandType;
using LogsResolver = SmartCollege.Connecter.API.SendLogsGQL;
using SmartCollege.Connecter.API;

namespace SmartCollege.Executor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                try
                {
                    await Recive();
                }
                catch (Exception e)
                {
                    Console.WriteLine("АШИБКА!!!!");
                }
            }

            static async Task Recive()
            {
                while(true)
                {
                    var Commands = (await GetCommadnsGQL.SendQueryAsync(Helper.Client, new GetCommadnsGQL.Variables { execute_statement = false }))
                        .Data.Commands;
                    foreach (var command in Commands)
                    {
                        #if DEBUG
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Новая инструкция от {command.username}, типа {command.type}, на время : '{command.time}'");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Команда : '{command.body}'");
                        #endif

                        // IS THIS KOTLIN?? WOW
                        string outp = command.type switch
                        {
                            CommandType.CMD => CMDCommand.Execute(command.body),
                            CommandType.PSEXEC => PsExecCommand.Execute(command.body),
                            _ => "Тип команды не найден",
                        };


                        // Отправка сообщения на апишку
                        var log = new LogsResolver.Variables
                        {
                            log = new LogsMessageInput()
                            {
                                commandId = command.id,
                                message = outp,
                                username = "SERVER"
                            }
                        };

                        await LogsResolver.SendMutationAsync(
                            Helper.Client,
                            log
                        );
                    }
                    await Task.Delay(5000);
                }
            }
        }
    }
}
