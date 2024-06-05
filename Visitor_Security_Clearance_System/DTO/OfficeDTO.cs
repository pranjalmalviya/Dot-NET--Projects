using Newtonsoft.Json;

namespace Visitor_Security_Clearance_System.DTO
{
    public class OfficeDTO
    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "managerId", NullValueHandling = NullValueHandling.Ignore)]
        public string ManagerId { get; set; }
    }
}
