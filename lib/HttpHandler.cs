using System.Net.Http.Headers;

namespace Sign_App_client;

public class HttpHandler
{
    private string serverIp = "127.0.0.1";
    private string serverPort = "5141";
    public string serverHost {get; set;}
    public string filesStorage = "./files/";
    private static HttpClient httpClient = new HttpClient();

    public HttpHandler(string serverHost, string serverPort,bool https){
        this.serverHost = serverHost;
        this.serverPort = serverPort;
        if(https){
            this.serverHost = "https://" + serverHost + ":" + serverPort;
        }
        else{
            this.serverHost = "http://" + serverHost + ":" + serverPort;
        }
    }

    public async Task<string> GetString(string query){
        return await httpClient.GetStringAsync(this.serverHost + query);
    }

    public async Task<string> PostString(string where, string data){
        StringContent content = new StringContent(data);
        var response = await httpClient.PostAsync(serverHost+where, content);
        return await response.Content.ReadAsStringAsync();
    }

    private string ClearFileName(string FileName){
        string Result = "";

        char[] name = FileName.ToCharArray();
        for (int i = name.Length - 1; i != -1; i--)
        {   
            if (name[i] == '/')
                break;
            Result = name[i] + Result;
        }
        
        return Result;
    }

    public async Task<string> UploadFile(string where, List<string> filenames){
        var FormContent = new MultipartFormDataContent();

        foreach(string filename in filenames){
            var content = new ByteArrayContent(await File.ReadAllBytesAsync(filename));
            string fname = ClearFileName(filename);
            FormContent.Add(content,name:fname,fileName:fname);
        }
        var response = await httpClient.PostAsync(this.serverHost+where, FormContent);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> DownloadFile(string where, string filename){
        StringContent content = new StringContent(filename);
        var response = await httpClient.PostAsync(serverHost+where, content);
        var file = await response.Content.ReadAsStreamAsync();
        using (var fileStream = new FileStream(filesStorage+filename, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return "Succ";
    }
}
