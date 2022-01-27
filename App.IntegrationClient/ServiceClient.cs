
namespace App.IntegrationClient;

public class ServiceClient
{

    public async Task<string> GetWeathersAsync()
    {
        HttpClient client = new HttpClient();
        //        string data = await (await client.GetAsync("https://localhost:7259/weatherforecast")).Content.ReadAsStringAsync();
        //https://bcaweatherapi.azurewebsites.net/weatherforecast
        string data = await (await client.GetAsync("https://bcaweatherapi.azurewebsites.net/weatherforecast")).Content.ReadAsStringAsync();

        //string data = await (await _client.GetAsync("weatherforecast")).Content.ReadAsStringAsync();
        return data;
    }

    public int HandleDICOMFile(MemoryStream buffer)
    {
        return (int)buffer.Length;
    }

}
