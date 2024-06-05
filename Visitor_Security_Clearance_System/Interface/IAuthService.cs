using Visitor_Security_Clearance_System.DTO;

namespace Visitor_Security_Clearance_System.Interface
{
    public interface IAuthService
    {
     
        Task<UserLoginDTO> Authenticate(string Email);

       // Task<UserLoginDTO> GetUserAsync(string uId, string email, string role);
    }
}
