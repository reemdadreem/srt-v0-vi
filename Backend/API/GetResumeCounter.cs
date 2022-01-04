using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume", collectionName:"counter", 
            ConnectionStringSetting = "AzureResumeConnectionString", Id = "index", PartitionKey = "index")] Counter counter,
            [CosmosDB(databaseName:"AzureResume",collectionName: "counter", 
            ConnectionStringSetting = "AzureResumeConnectionString", Id = "index", PartitionKey = "index")] out Counter updatedCounter,
            ILogger log)
        {
            log.LogInformation("AzureResume was triggered");

            updatedCounter = counter;
            updatedCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(counter);

           
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };

        }
    }
}
