using Newtonsoft.Json;
using Visitor_Security_Clearance_System.Common;

namespace Visitor_Security_Clearance_System.Entity
{
    public class VisitorEntity:BEntity
    {
 

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        public long PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "companyname", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "purpose", NullValueHandling = NullValueHandling.Ignore)]
        public string Purpose { get; set; }

        [JsonProperty(PropertyName = "entrytime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime EntryTime { get; set; }

        [JsonProperty(PropertyName = "exittime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExitTime { get; set; }

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }


    }
}
