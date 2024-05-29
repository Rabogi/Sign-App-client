using Microsoft.VisualBasic;

namespace Sign_App_client;

public class HttpHandler
{
    private string serverIp = "127.0.0.1";
    private string serverPort = "5141";
    public string serverHost {get; set;}
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

    // public async Task<string> GetString(string query){
    //     string response = await this.httpClient.GetStringAsync(serverHost + query);
    //     return response;
    // }

    public async Task<string> GetString(string query){
        return await httpClient.GetStringAsync(this.serverHost + query);
    }

    public async Task<string> PostString(string where, string data){
        StringContent content = new StringContent(data);
        var response = await httpClient.PostAsync(serverHost+where, content);
        return await response.Content.ReadAsStringAsync();
    }

}
