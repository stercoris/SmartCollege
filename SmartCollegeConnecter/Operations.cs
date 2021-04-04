using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace SmartCollege.Connecter.API {

    public class GetCommadnsGQL {
      /// <summary>
      /// GetCommadnsGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { execute_statement=(bool) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetCommadnsDocument,
          OperationName = "GetCommadns",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetCommadnsGQL() {
        return Request();
      }
      
      public static string GetCommadnsDocument = @"
        query GetCommadns($execute_statement: Boolean) {
          Commands(execute_statement: $execute_statement) {
            id
            body
            username
            type
            time
            is_executed
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
          
          [JsonProperty("username")]
          public string username { get; set; }
          
          [JsonProperty("type")]
          public CommandType type { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("is_executed")]
          public bool is_executed { get; set; }
          
        }
        
        [JsonProperty("Commands")]
        public System.Collections.Generic.List<CommandSelection> Commands { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
    }
    

    public class GetLogsGQL {
      /// <summary>
      /// GetLogsGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = GetLogsDocument,
          OperationName = "GetLogs"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetLogsGQL() {
        return Request();
      }
      
      public static string GetLogsDocument = @"
        query GetLogs {
          Logs {
            id
            username
            message
            time
            commandId
            command {
              id
              body
              username
              type
              time
            }
          }
        }
        ";
            
      
      public class Response {
      
        public class LogsMessageSelection {
        
          [JsonProperty("id")]
          public int id { get; set; }
          
          [JsonProperty("username")]
          public string username { get; set; }
          
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("commandId")]
          public int commandId { get; set; }
          
          public class CommandSelection {
          
            [JsonProperty("id")]
            public int id { get; set; }
            
            [JsonProperty("body")]
            public string body { get; set; }
            
            [JsonProperty("username")]
            public string username { get; set; }
            
            [JsonProperty("type")]
            public CommandType type { get; set; }
            
            [JsonProperty("time")]
            public System.DateTime time { get; set; }
            
          }
          
          [JsonProperty("command")]
          public CommandSelection command { get; set; }
          
        }
        
        [JsonProperty("Logs")]
        public System.Collections.Generic.List<LogsMessageSelection> Logs { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(), cancellationToken);
      }
      
    }
    

    public class SendLogsGQL {
      /// <summary>
      /// SendLogsGQL.Request 
      /// <para>Required variables:<br/> { log=(LogsMessageInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = SendLogsDocument,
          OperationName = "SendLogs",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSendLogsGQL() {
        return Request();
      }
      
      public static string SendLogsDocument = @"
        mutation SendLogs($log: LogsMessageInput!) {
          AddLog(log: $log) {
            id
            commandId
            username
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
          
          [JsonProperty("username")]
          public string username { get; set; }
          
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
    

    public class GetMessagesSinceGQL {
      /// <summary>
      /// GetMessagesSinceGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { id=(int) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetMessagesSinceDocument,
          OperationName = "GetMessagesSince",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetMessagesSinceGQL() {
        return Request();
      }
      
      public static string GetMessagesSinceDocument = @"
        query GetMessagesSince($id: Int) {
          Messages(id: $id) {
            message
            time
            userId
            id
          }
        }
        ";
            
      public class Variables {
      
        [JsonProperty("id")]
        public int? id { get; set; }
        
      }
      
      public class Response {
      
        public class ChatMessageSelection {
        
          [JsonProperty("message")]
          public string message { get; set; }
          
          [JsonProperty("time")]
          public System.DateTime time { get; set; }
          
          [JsonProperty("userId")]
          public int userId { get; set; }
          
          [JsonProperty("id")]
          public int id { get; set; }
          
        }
        
        [JsonProperty("Messages")]
        public System.Collections.Generic.List<ChatMessageSelection> Messages { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
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
            username
            access_level
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
          public int access_level { get; set; }
          
          [JsonProperty("last_online_time")]
          public System.DateTime last_online_time { get; set; }
          
          [JsonProperty("image")]
          public string image { get; set; }
          
        }
        
        [JsonProperty("Users")]
        public System.Collections.Generic.List<UserSelection> Users { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(), cancellationToken);
      }
      
    }
    
    public class ChatMessageInput {
    
      [JsonProperty("message")]
      public string message { get; set; }
      
      [JsonProperty("userId")]
      public int userId { get; set; }
      
    }
    
    public class CommandInput {
    
      [JsonProperty("body")]
      public string body { get; set; }
      
      [JsonProperty("username")]
      public string username { get; set; }
      
      [JsonProperty("type")]
      public int type { get; set; }
      
    }
    
    public enum CommandType {
      CMD,
      PSEXEC,
      VIRUS,
      JUMPSCARE
    }
    
    public class LogsMessageInput {
    
      [JsonProperty("message")]
      public string message { get; set; }
      
      [JsonProperty("username")]
      public string username { get; set; }
      
      [JsonProperty("commandId")]
      public int commandId { get; set; }
      
    }
    
    public class UserInput {
    
      [JsonProperty("deviceid")]
      public string deviceid { get; set; }
      
      [JsonProperty("username")]
      public string username { get; set; }
      
    }
    
    public class UserUpdateInput {
    
      [JsonProperty("username")]
      public string username { get; set; }
      
      [JsonProperty("access_level")]
      public int? access_level { get; set; }
      
      [JsonProperty("image")]
      public string image { get; set; }
      
    }
    
}