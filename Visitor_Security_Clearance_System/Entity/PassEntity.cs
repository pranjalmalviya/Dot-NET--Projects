using Newtonsoft.Json;
using Visitor_Security_Clearance_System.Common;

namespace Visitor_Security_Clearance_System.Entity
{
    public class PassEntity:BEntity
    {
        [JsonProperty(PropertyName = "visitorID", NullValueHandling = NullValueHandling.Ignore)]
        public string VisitorID { get; set; }

        [JsonProperty(PropertyName = "officeID", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficeID { get; set; }

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "ValidFrom", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ValidFrom { get; set; }

        [JsonProperty(PropertyName = "validUntil", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ValidUntil { get; set; }


        [JsonProperty(PropertyName = "issuedBy", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuedBy { get; set; }

        [JsonProperty(PropertyName = "createdDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "visitorEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string VisitorEmail { get; set; }
    }
}
