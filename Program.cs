namespace Sign_App_client;

class Program
{   
    static string serverhost = "10.147.17.103";
    static string serverport = "5141";
    static async Task<int> Main()
    {   
        HttpHandler handler = new HttpHandler(serverhost,serverport,false);
        Console.WriteLine(await handler.GetString("/weatherforecast"));
        Console.WriteLine(await handler.PostString("/hash256","test"));
        return 0;
    }
}

