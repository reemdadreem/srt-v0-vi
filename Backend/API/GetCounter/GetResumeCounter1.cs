using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace Company.Function
{
    public static class Company.Function
    {
        private const int V = 1;

        [FunctionName("GetResumeCounter1")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"resi-db", collectionName:"resi-container", ConnectionStringSetting = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] GetResumeCounter1 counter,
            [CosmosDB(databaseName:"resi-db", collectionName:"resi-container", ConnectionStringSetting = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] out GetResumeCounter1 updatedCounter,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Counter += "1";

            return new HttpResponseMessage(System.Net.HttpStatusCode.Ok)
            {
                Content = new StringContent (jsonToReturn, Encoding.UTF8, "application/json") 
            };
        }
    }
}
