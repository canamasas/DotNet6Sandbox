
namespace App.IntegrationClient
{
    public interface IServiceClient
    {
        Task<string> GetWeathersAsync();
    }
}