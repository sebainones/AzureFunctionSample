using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Company.Function
{
    public static class BlobTriggerCSharp
    {       

        [FunctionName("BlobTriggerCSharp")]
        public static async System.Threading.Tasks.Task RunAsync([BlobTrigger("vehiclescontainer/{name}", Connection = "AzureWebJobsStorage")]CloudBlockBlob  myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n URI: {myBlob.StorageUri}");

            try
            {
                
                await myBlob.DeleteIfExistsAsync();
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
            }
        }
    }
}
