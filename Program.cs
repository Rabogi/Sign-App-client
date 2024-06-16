using Sign_App_server;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
        // var keys = SlimShady.GetKeyRSAKeyPair(2048);
        // var sig = SlimShady.SignData(File.ReadAllText("./files/cat.jpg"), keys["PrivateKey"]);
        // Console.WriteLine(sig.Length);

        HttpHandler httpHandler = new HttpHandler(serverhost, serverport, false);
        var files = new List<string>{"./files/cat.jpg","./files/CWYMDms1cCw.jpg"};
        var ret = await httpHandler.UploadFile("/uploadfiles",files,"72706A9A434B0AAAABCEB036A48236AFEBCE464555AF87CA77C1C047FA2E9A3");
        var hashes = new List<string>();
        foreach (var file in files){
            hashes.Add(SlimShady.Sha256Hash(File.ReadAllText(file)));
        }
        foreach (var hash in hashes){
            Console.WriteLine(hash);
        }
        var data = JsonHandler.ReadJson(ret);
        foreach (var hash in data){
            Console.WriteLine(hash.Value.ToString());
        }
        

        return 0;
    }



    void ReadCache(){
        
    }
}

