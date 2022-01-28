using App.IntegrationClient;
using System.IO;
using Xunit;

namespace App.IntegrationClientTest
{
    public class ServiceClientTests
    {
        [Fact]
        public void Test1()
        {
            int dicomResult;
            int expectedResult;
            var serviceClient = new ServiceClient();
            var buffer = new System.IO.MemoryStream();
            var fb = File.ReadAllBytes(@"C:\temp\DICOM_GOOD_IMAGES\EC08\EC08\RP.1.2.246.352.71.5.150896809914.4876.20200826080322.dcm");
            using var memoryStream = new MemoryStream(fb);
            dicomResult = serviceClient.HandleDICOMFile(memoryStream);
            expectedResult = (int)memoryStream.Length;
            
            Assert.True(dicomResult == expectedResult);
        }

        [Fact]
        public async void GetParseDicomData()
        {
            string dicomResult;
            int expectedResult;
            var serviceClient = new ServiceClient();
            var buffer = new System.IO.MemoryStream();
            var fb = File.ReadAllBytes(@"C:\temp\DICOM_GOOD_IMAGES\EC08\EC08\RP.1.2.246.352.71.5.150896809914.4876.20200826080322.dcm");
            dicomResult = await serviceClient.ParseDICOMFile(fb);

            Assert.True(dicomResult == "EC08");
        }
    }
}