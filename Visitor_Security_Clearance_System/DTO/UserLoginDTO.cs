using Newtonsoft.Json;

namespace Visitor_Security_Clearance_System.DTO
{
    public class UserLoginDTO
    {


        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
         public string Email { get; set; }

         [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
         public string Role { get; set; }

        


       /* [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }


        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
       public string Email { get; set; }

       [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
       public string Role { get; set; }*/



    }
}
