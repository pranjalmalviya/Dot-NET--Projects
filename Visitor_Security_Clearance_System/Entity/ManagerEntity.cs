using Newtonsoft.Json;
using Visitor_Security_Clearance_System.Common;

namespace Visitor_Security_Clearance_System.Entity
{
    public class ManagerEntity : BEntity
    {

       

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        public long PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }
    }
}
