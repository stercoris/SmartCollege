using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCollege.Connecter;

namespace SmartCollege.Room
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var chat = await Connecter.API.GetMessagesSinceGQL.SendQueryAsync(Helper.Client, new Connecter.API.GetMessagesSinceGQL.Variables { id = 0 });
        }
    }
}
