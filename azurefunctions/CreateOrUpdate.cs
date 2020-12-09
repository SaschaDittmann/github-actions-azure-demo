using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctions.Data;

namespace AzureFunctions
{
    public static class CreateOrUpdate
    {
        [FunctionName("CreateOrUpdate")]  
        public static async Task<bool> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", "put", Route = "CreateOrUpdate")]HttpRequest req, 
            ILogger log)  
        {  
            log.LogInformation("C# HTTP trigger function to create a record into Cosmos DB");  
            try  
            {  
                IDocumentDBRepository<Employee> Respository = new DocumentDBRepository<Employee>();  
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();  
                var employee = JsonConvert.DeserializeObject<Employee>(requestBody);  
                if (req.Method == "POST")  
                {  
                    employee.Id = null;  
                    await Respository.CreateItemAsync(employee, "Employee");  
                }  
                else  
                {  
                    await Respository.UpdateItemAsync(employee.Id, employee, "Employee");  
                }  
                return true;  
            }  
            catch  
            {  
                log.LogInformation("Error occured while creating a record into Cosmos DB");  
                return false;  
            }  
  
        } 
    }
}
