﻿using Sign_App_server;

namespace Sign_App_client;

class Program
{   
    static string serverhost = "10.147.17.103";
    static string serverport = "5141";
    static async Task<int> Main()
    {   
        HttpHandler handler = new HttpHandler(serverhost,serverport,false);
        // Console.WriteLine(await handler.GetString("/weatherforecast"));
        // Console.WriteLine(await handler.PostString("/hash256","test"));
        // List<string> list = new List<string>();
        // list.Add("./files/3v1L0XNoPog.jpg");
        // list.Add("./files/CWYMDms1cCw.jpg");
        // Console.WriteLine(await handler.UploadFile("/uploadfiles",list));
        Console.WriteLine(await handler.DownloadFile("/downloadfiles","3v1L0XNoPog.jpg"));

        // Console.WriteLine(SlimShady.Sha256Hash("test"));

        return 0;
    }
}

