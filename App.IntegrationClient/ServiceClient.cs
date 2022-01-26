
namespace App.IntegrationClient;

    public class ServiceClient
    {
        
        public async Task<string> GetWeathersAsync()
        {
            HttpClient client = new HttpClient();
            string data = await (await client.GetAsync("https://localhost:7259/weatherforecast")).Content.ReadAsStringAsync();
            return data;
        }  

    }
