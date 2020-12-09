using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctions.Data;

namespace AzureFunctions
{
    public static class GetSingle
    {
        [FunctionName("GetSingle")]
        public static async Task<Employee> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Get/{id}/{cityName}")]HttpRequest req, 
            ILogger log, string id, string cityName)  
        {  
            log.LogInformation("C# HTTP trigger function to get a single data from Cosmos DB");  
  
            IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();  
            var employees = await Respository.GetItemsAsync(d => d.Id == id && d.Cityname == cityName, "Employee");  
            
            Employee employee = new Employee();  
            foreach (var emp in employees)  
            {  
                employee = emp;  
                break;  
            }  
            return employee;  
        }
    }
}
