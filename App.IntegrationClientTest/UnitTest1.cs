using App.IntegrationClient;
using System.IO;
using Xunit;

namespace App.IntegrationClientTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int dicomResult;
            int expectedResult;
            var serviceClient = new ServiceClient();
            var buffer = new System.IO.MemoryStream();
            using (FileStream fs = File.OpenRead(@"C:\temp\DICOM_GOOD_IMAGES\EC08\EC08\CT.1.2.246.352.71.20.8.12.11.36.39.9157842.dcm"))
            {
                fs.CopyTo(buffer);
                expectedResult = (int)buffer.Length;
                dicomResult = serviceClient.HandleDICOMFile(buffer);
            }
            Assert.True(dicomResult == expectedResult);
        }
    }
}