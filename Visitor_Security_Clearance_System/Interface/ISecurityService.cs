using Visitor_Security_Clearance_System.DTO;

namespace Visitor_Security_Clearance_System.Interface
{
    public interface ISecurityService
    {
        Task<SecurityDTO> RegisterSecurity(SecurityDTO securityDTO);

        Task<SecurityDTO> GetSecurityByEmail(string Email);

        Task<SecurityDTO> GetSecurityByUId(string UId);

        Task<SecurityDTO> UpdateSecurity(SecurityDTO securityDTO);

        Task<string> DeleteSecurity(string UId);
    }
}
