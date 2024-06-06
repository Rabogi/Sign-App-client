using Sign_App_server;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Sign_App_client;

class Program
{   
    static string serverhost = "10.147.17.103";
    static string serverport = "5141";
    static async Task<int> Main()
    {   
        var res = JsonHandler.ReadJson(File.ReadAllText("./config.json"));
        Console.WriteLine(JsonHandler.MakeJson(res));

        return 0;
    }
}

