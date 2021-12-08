using System;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace WrongDoor.Connector {

    public class AddChatMessageGQL {
      /// <summary>
      /// AddChatMessageGQL.Request 
      /// <para>Required variables:<br/> { message=(ChatMessageInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = AddChatMessageDocument,
          OperationName = "AddChatMessage",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getAddChatMessageGQL() {
        return Request();
      }
      
      public static string AddChatMessageDocument = @"
        mutation AddChatMessage($message: ChatMessageInput!) {
          AddMessage(message: $message) {
            id
            userId
            message
            time
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("message")]
        public ChatMessageInput message { get; set; }
        
      }
      
      public class Response {
      
        public class ChatMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
        }
        
        [JsonProperty("AddMessage")]
        public ChatMessageSelection AddMessage { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class DeleteChatMessageGQL {
      /// <summary>
      /// DeleteChatMessageGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = DeleteChatMessageDocument,
          OperationName = "DeleteChatMessage",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getDeleteChatMessageGQL() {
        return Request();
      }
      
      public static string DeleteChatMessageDocument = @"
        mutation DeleteChatMessage($id: Int!) {
          DeleteMessage(id: $id) {
            id
            userId
            message
            time
            deleted
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class ChatMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("DeleteMessage")]
        public ChatMessageSelection DeleteMessage { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class GetChatMessagesGQL {
      /// <summary>
      /// GetChatMessagesGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetChatMessagesDocument,
          OperationName = "GetChatMessages",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetChatMessagesGQL() {
        return Request();
      }
      
      public static string GetChatMessagesDocument = @"
        query GetChatMessages($id: Int!) {
          Messages(id: $id) {
            message
            userId
            time
            id
            deleted
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class ChatMessageSelection {
        
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("Messages")]
        public System.Collections.Generic.List<ChatMessageSelection> Messages { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class SubsribeToNewMessagesGQL {
      /// <summary>
      /// SubsribeToNewMessagesGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubsribeToNewMessagesDocument,
          OperationName = "SubsribeToNewMessages"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubsribeToNewMessagesGQL() {
        return Request();
      }
      
      public static string SubsribeToNewMessagesDocument = @"
        subscription SubsribeToNewMessages {
          newMessage {
            id
            userId
            message
            time
            deleted
          }
        }
        ";
            
      
      public class Response {
      
        public class ChatMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("newMessage")]
        public ChatMessageSelection newMessage { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class SubsribeToDeletedMessagesGQL {
      /// <summary>
      /// SubsribeToDeletedMessagesGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubsribeToDeletedMessagesDocument,
          OperationName = "SubsribeToDeletedMessages"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubsribeToDeletedMessagesGQL() {
        return Request();
      }
      
      public static string SubsribeToDeletedMessagesDocument = @"
        subscription SubsribeToDeletedMessages {
          deletedMessage {
            id
            userId
            message
            time
            deleted
          }
        }
        ";
            
      
      public class Response {
      
        public class ChatMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("deletedMessage")]
        public ChatMessageSelection deletedMessage { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class AddCommandGQL {
      /// <summary>
      /// AddCommandGQL.Request 
      /// <para>Required variables:<br/> { command=(CommandInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = AddCommandDocument,
          OperationName = "AddCommand",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getAddCommandGQL() {
        return Request();
      }
      
      public static string AddCommandDocument = @"
        mutation AddCommand($command: CommandInput!) {
          AddCommand(command: $command) {
            id
            userId
            body
            type
            time
            is_executed
            deleted
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("command")]
        public CommandInput command { get; set; }
        
      }
      
      public class Response {
      
        public class CommandSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("body")]
          public string body { get; set; }
          
          [JsonProperty("type")]
          public CommandType type { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("is_executed")]
          public bool is_executed { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("AddCommand")]
        public CommandSelection AddCommand { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class DeleteCommandGQL {
      /// <summary>
      /// DeleteCommandGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = DeleteCommandDocument,
          OperationName = "DeleteCommand",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getDeleteCommandGQL() {
        return Request();
      }
      
      public static string DeleteCommandDocument = @"
        mutation DeleteCommand($id: Int!) {
          DeleteCommand(id: $id) {
            id
            body
            userId
            type
            time
            is_executed
            deleted
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class CommandSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("body")]
          public string body { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("type")]
          public CommandType type { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("is_executed")]
          public bool is_executed { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("DeleteCommand")]
        public CommandSelection DeleteCommand { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class GetCommandsGQL {
      /// <summary>
      /// GetCommandsGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { execute_statement=(bool) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetCommandsDocument,
          OperationName = "GetCommands",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetCommandsGQL() {
        return Request();
      }
      
      public static string GetCommandsDocument = @"
        query GetCommands($execute_statement: Boolean) {
          Commands(execute_statement: $execute_statement) {
            id
            body
            userId
            type
            time
            is_executed
            deleted
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("execute_statement")]
        public bool? execute_statement { get; set; }
        
      }
      
      public class Response {
      
        public class CommandSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("body")]
          public string body { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("type")]
          public CommandType type { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("is_executed")]
          public bool is_executed { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("Commands")]
        public System.Collections.Generic.List<CommandSelection> Commands { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class SubscribeToNewCommandsGQL {
      /// <summary>
      /// SubscribeToNewCommandsGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubscribeToNewCommandsDocument,
          OperationName = "SubscribeToNewCommands"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubscribeToNewCommandsGQL() {
        return Request();
      }
      
      public static string SubscribeToNewCommandsDocument = @"
        subscription SubscribeToNewCommands {
          newCommand {
            id
            body
            userId
            type
            time
            is_executed
            deleted
          }
        }
        ";
            
      
      public class Response {
      
        public class CommandSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("body")]
          public string body { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("type")]
          public CommandType type { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("is_executed")]
          public bool is_executed { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("newCommand")]
        public CommandSelection newCommand { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class SubscribeToDeletedCommandGQL {
      /// <summary>
      /// SubscribeToDeletedCommandGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubscribeToDeletedCommandDocument,
          OperationName = "SubscribeToDeletedCommand"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubscribeToDeletedCommandGQL() {
        return Request();
      }
      
      public static string SubscribeToDeletedCommandDocument = @"
        subscription SubscribeToDeletedCommand {
          deletedCommand {
            id
            body
            userId
            type
            time
            is_executed
            deleted
          }
        }
        ";
            
      
      public class Response {
      
        public class CommandSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("body")]
          public string body { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("type")]
          public CommandType type { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("is_executed")]
          public bool is_executed { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
        }
        
        [JsonProperty("deletedCommand")]
        public CommandSelection deletedCommand { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class SubscribeToCommandExecutionGQL {
      /// <summary>
      /// SubscribeToCommandExecutionGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubscribeToCommandExecutionDocument,
          OperationName = "SubscribeToCommandExecution"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubscribeToCommandExecutionGQL() {
        return Request();
      }
      
      public static string SubscribeToCommandExecutionDocument = @"
        subscription SubscribeToCommandExecution {
          newLogMessage {
            id
            commandId
          }
        }
        ";
            
      
      public class Response {
      
        public class LogsMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("commandId")]
          public int commandId { get; set; }
          
        }
        
        [JsonProperty("newLogMessage")]
        public LogsMessageSelection newLogMessage { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class AddLogMessageGQL {
      /// <summary>
      /// AddLogMessageGQL.Request 
      /// <para>Required variables:<br/> { log=(LogsMessageInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = AddLogMessageDocument,
          OperationName = "AddLogMessage",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getAddLogMessageGQL() {
        return Request();
      }
      
      public static string AddLogMessageDocument = @"
        mutation AddLogMessage($log: LogsMessageInput!) {
          AddLog(log: $log) {
            id
            commandId
            userId
            message
            time
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("log")]
        public LogsMessageInput log { get; set; }
        
      }
      
      public class Response {
      
        public class LogsMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("commandId")]
          public int commandId { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
        }
        
        [JsonProperty("AddLog")]
        public LogsMessageSelection AddLog { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class DeleteLogMessageGQL {
      /// <summary>
      /// DeleteLogMessageGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = DeleteLogMessageDocument,
          OperationName = "DeleteLogMessage",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getDeleteLogMessageGQL() {
        return Request();
      }
      
      public static string DeleteLogMessageDocument = @"
        mutation DeleteLogMessage($id: Int!) {
          DeleteLog(id: $id) {
            id
            commandId
            userId
            message
            deleted
            time
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class LogsMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("commandId")]
          public int commandId { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
        }
        
        [JsonProperty("DeleteLog")]
        public LogsMessageSelection DeleteLog { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class GetLogMessagesGQL {
      /// <summary>
      /// GetLogMessagesGQL.Request 
      /// <para>Required variables:<br/> { id=(int) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetLogMessagesDocument,
          OperationName = "GetLogMessages",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetLogMessagesGQL() {
        return Request();
      }
      
      public static string GetLogMessagesDocument = @"
        query GetLogMessages($id: Int!) {
          Logs(id: $id) {
            id
            commandId
            userId
            message
            deleted
            time
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int id { get; set; }
        
      }
      
      public class Response {
      
        public class LogsMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("commandId")]
          public int commandId { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
        }
        
        [JsonProperty("Logs")]
        public System.Collections.Generic.List<LogsMessageSelection> Logs { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class SubscribeToNewLogMessagesGQL {
      /// <summary>
      /// SubscribeToNewLogMessagesGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubscribeToNewLogMessagesDocument,
          OperationName = "SubscribeToNewLogMessages"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubscribeToNewLogMessagesGQL() {
        return Request();
      }
      
      public static string SubscribeToNewLogMessagesDocument = @"
        subscription SubscribeToNewLogMessages {
          newLogMessage {
            id
            userId
            message
            deleted
            time
            commandId
          }
        }
        ";
            
      
      public class Response {
      
        public class LogsMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("commandId")]
          public int commandId { get; set; }
          
        }
        
        [JsonProperty("newLogMessage")]
        public LogsMessageSelection newLogMessage { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class SubscribeToDeletedLogMessagesGQL {
      /// <summary>
      /// SubscribeToDeletedLogMessagesGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubscribeToDeletedLogMessagesDocument,
          OperationName = "SubscribeToDeletedLogMessages"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubscribeToDeletedLogMessagesGQL() {
        return Request();
      }
      
      public static string SubscribeToDeletedLogMessagesDocument = @"
        subscription SubscribeToDeletedLogMessages {
          deletedLogMessage {
            id
            commandId
            userId
            message
            deleted
            time
          }
        }
        ";
            
      
      public class Response {
      
        public class LogsMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("commandId")]
          public int commandId { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
        }
        
        [JsonProperty("deletedLogMessage")]
        public LogsMessageSelection deletedLogMessage { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class CreateUserGQL {
      /// <summary>
      /// CreateUserGQL.Request 
      /// <para>Required variables:<br/> { user=(UserInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CreateUserDocument,
          OperationName = "CreateUser",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCreateUserGQL() {
        return Request();
      }
      
      public static string CreateUserDocument = @"
        mutation CreateUser($user: UserInput!) {
          CreateUser(User: $user) {
            token
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("user")]
        public UserInput user { get; set; }
        
      }
      
      public class Response {
      
        public class TokenSelection {
        
          [JsonProperty("token")]
          public string token { get; set; }
          
        }
        
        [JsonProperty("CreateUser")]
        public TokenSelection CreateUser { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class GetUsersGQL {
      /// <summary>
      /// GetUsersGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = GetUsersDocument,
          OperationName = "GetUsers"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetUsersGQL() {
        return Request();
      }
      
      public static string GetUsersDocument = @"
        query GetUsers {
          Users {
            id
            deviceid
            access_level
            deleted
            last_online_time
            image
            username
          }
        }
        ";
            
      
      public class Response {
      
        public class UserSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("deviceid")]
          public string deviceid { get; set; }
          
          [JsonProperty("access_level")]
          public AccessLevel access_level { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
          [JsonProperty("last_online_time")]
          public System.DateTime last_online_time { get; set; }
          
          [JsonProperty("image")]
          public string image { get; set; }
          
          [JsonProperty("username")]
          public string username { get; set; }
          
        }
        
        [JsonProperty("Users")]
        public System.Collections.Generic.List<UserSelection> Users { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(), cancellationToken);
      }
      
    }
    

    public class SubscribeToNewUserGQL {
      /// <summary>
      /// SubscribeToNewUserGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubscribeToNewUserDocument,
          OperationName = "SubscribeToNewUser"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubscribeToNewUserGQL() {
        return Request();
      }
      
      public static string SubscribeToNewUserDocument = @"
        subscription SubscribeToNewUser {
          newUser {
            id
            deviceid
            username
            access_level
            deleted
            last_online_time
            image
          }
        }
        ";
            
      
      public class Response {
      
        public class UserSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("deviceid")]
          public string deviceid { get; set; }
          
          [JsonProperty("username")]
          public string username { get; set; }
          
          [JsonProperty("access_level")]
          public AccessLevel access_level { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
          [JsonProperty("last_online_time")]
          public System.DateTime last_online_time { get; set; }
          
          [JsonProperty("image")]
          public string image { get; set; }
          
        }
        
        [JsonProperty("newUser")]
        public UserSelection newUser { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    

    public class SubscribeToDeletedUserGQL {
      /// <summary>
      /// SubscribeToDeletedUserGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = SubscribeToDeletedUserDocument,
          OperationName = "SubscribeToDeletedUser"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSubscribeToDeletedUserGQL() {
        return Request();
      }
      
      public static string SubscribeToDeletedUserDocument = @"
        subscription SubscribeToDeletedUser {
          deletedUser {
            id
            deviceid
            username
            access_level
            deleted
            last_online_time
            image
          }
        }
        ";
            
      
      public class Response {
      
        public class UserSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("deviceid")]
          public string deviceid { get; set; }
          
          [JsonProperty("username")]
          public string username { get; set; }
          
          [JsonProperty("access_level")]
          public AccessLevel access_level { get; set; }
          
          [JsonProperty("deleted")]
          public bool deleted { get; set; }
          
          [JsonProperty("last_online_time")]
          public System.DateTime last_online_time { get; set; }
          
          [JsonProperty("image")]
          public string image { get; set; }
          
        }
        
        [JsonProperty("deletedUser")]
        public UserSelection deletedUser { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    
    public enum AccessLevel {
      Admin,
      Denied,
      Pro,
      User
    }
    
    public class ChatMessageInput {
    
      [JsonProperty("message")]
      public string message { get; set; }
      
    }
    
    public class CommandInput {
    
      [JsonProperty("body")]
      public string body { get; set; }
      
      [JsonProperty("type")]
      public int type { get; set; }
      
    }
    
    public enum CommandType {
      CMD,
      JUMPSCARE,
      PSEXEC,
      VIRUS
    }
    
    public class LogsMessageInput {
    
      [JsonProperty("commandId")]
      public int commandId { get; set; }
      
      [JsonProperty("message")]
      public string message { get; set; }
      
    }
    
    public class UserInput {
    
      [JsonProperty("deviceid")]
      public string deviceid { get; set; }
      
      [JsonProperty("username")]
      public string username { get; set; }
      
    }
    
    public class UserUpdateInput {
    
      [JsonProperty("access_level")]
      public int? access_level { get; set; }
      
      [JsonProperty("image")]
      public string image { get; set; }
      
      [JsonProperty("username")]
      public string username { get; set; }
      
    }
    
}