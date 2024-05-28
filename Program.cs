using RestSharp;
using System.Net;

class Program
{
    
    static int Main()
    {   
        string serverhost = "10.147.17.103";
        string serverport = "5141";
        // var options = new RestClientOptions(serverhost + ":" + serverport);
        // var client = new RestClient();
        // var request = new RestRequest("weatherforecast");

        var url = serverhost + ":" + serverport + "/weatherforecast";

        var response = "";

        using (var wb = new WebClient())
        {
           response = wb.DownloadString("http://10.147.17.103:5141/weatherforecast");
        }

        

        Console.WriteLine(response);

        return 0;
    }
}

