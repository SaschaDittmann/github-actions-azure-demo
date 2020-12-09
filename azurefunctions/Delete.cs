using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctions.Data;

namespace AzureFunctions
{
    public static class Delete
    {
        [FunctionName("Delete")]  
        public static async Task<bool> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Delete/{id}/{cityName}")]HttpRequest req, 
            ILogger log, string id, string cityName)  
        {  
            log.LogInformation("C# HTTP trigger function to delete a record from Cosmos DB");  
  
            IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();  
            try  
            {  
                await Respository.DeleteItemAsync(id, "Employee", cityName);  
                return true;  
            }  
            catch  
            {  
                return false;  
            }  
        }  
    }
}
