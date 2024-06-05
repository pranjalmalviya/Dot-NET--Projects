using Newtonsoft.Json;
using Visitor_Security_Clearance_System.Common;

namespace Visitor_Security_Clearance_System.Entity
{
    public class OfficeEntity : BEntity
    {
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "managerId", NullValueHandling = NullValueHandling.Ignore)]
        public string ManagerId { get; set; }
    }
}
