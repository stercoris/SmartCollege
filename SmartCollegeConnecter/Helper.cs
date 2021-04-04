using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Command = SmartCollege.Connecter.API.GetCommadnsGQL.Response.CommandSelection;

namespace SmartCollege.Connecter
{
    public static class Helper
    {

        // Возможен баг, ПАТАМУЧТА какието додики обсуждали, что енум не сериали.. сер.. серит в строку,
        // после чего разрабы добавили кастомный конвертер,
        // в котором енумы, как бы ты не старался, не сериализируются в Int
        // (https://github.com/graphql-dotnet/graphql-client/issues/129)
        private static GraphQLHttpClient _client;
        public static GraphQLHttpClient Client
        {
            get {
                if(_client == null) _client = new GraphQLHttpClient(Config.ApiUrl, new NewtonsoftJsonSerializer());
                return (_client);
            }
        }
    }
}
