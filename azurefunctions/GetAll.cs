using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AzureFunctions.Data;

namespace AzureFunctions
{
    public static class GetAll
    {
        [FunctionName("GetAll")]
        public static async Task<IEnumerable<Employee>> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Get")]HttpRequest req, 
            ILogger log)  
        {  
            log.LogInformation("C# HTTP trigger function to get all data from Cosmos DB");  
  
            IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();  
            return await Respository.GetItemsAsync("Employee");  
        } 
    }
}
