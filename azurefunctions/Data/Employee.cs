using Newtonsoft.Json;

namespace AzureFunctions.Data
{
    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
        
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }
        
        [JsonProperty(PropertyName = "designation")]
        public string Designation { get; set; }
        
        [JsonProperty(PropertyName = "cityname")]
        public string Cityname { get; set; }
    }
}
