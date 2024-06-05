using Visitor_Security_Clearance_System.CosmosDB;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Interface;

namespace Visitor_Security_Clearance_System.Service
{
    public class AuthService : IAuthService
    {
        public readonly ICosmosDBService _cosmosDBService;

        public AuthService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        public async Task<UserLoginDTO> Authenticate(string Email)
        {
            var response= await _cosmosDBService.GetUserByEmail(Email);
            return response;
        }

        /*public async Task<UserLoginDTO> GetUserAsync(string uId, string email, string role)
        {
           
            var user = await _cosmosDBService.GetUserAsync(uId, email, role);
            return user;
        }*/

    }
}
