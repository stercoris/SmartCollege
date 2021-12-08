using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http.Headers;

namespace WrongDoor.Connecter
{
    public static class ClientHandler
    {
        // Возможен баг, ПАТАМУЧТА какието додики обсуждали, что енум не сериали.. сер.. серит в строку,
        // после чего разрабы добавили кастомный конвертер,
        // в котором енумы, как бы ты не старался, не сериализируются в Int
        // (https://github.com/graphql-dotnet/graphql-client/issues/129)
        private static GraphQLHttpClient _client;
        public static GraphQLHttpClient Client
        {
            get
            {
                var graphqlUrl = $"{Properties.Resources.ServerUrl}:{Properties.Resources.ServerPort}{Properties.Resources.GraphqlEndpoint}";
                if (_client == null) _client = new GraphQLHttpClient(graphqlUrl, new NewtonsoftJsonSerializer());

                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Properties.Resources.Token);

                return (_client);
            }
        }
    }
}