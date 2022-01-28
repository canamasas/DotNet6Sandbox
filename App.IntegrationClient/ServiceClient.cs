using FellowOakDicom;

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
        //var dataset2 = DicomFile.OpenAsync(@"C:\temp\DICOM_GOOD_IMAGES\EC08\EC08\RP.1.2.246.352.71.5.150896809914.4876.20200826080322.dcm");
        return (int)buffer.Length;
    }

    public async Task<string> ParseDICOMFile(byte[] dicomData)
    {
        using var memoryStream = new MemoryStream(dicomData);
        var dataset = await DicomFile.OpenAsync(memoryStream);
        var result = dataset.Dataset.GetString(DicomTag.PatientID);
        return result;
    }
}
