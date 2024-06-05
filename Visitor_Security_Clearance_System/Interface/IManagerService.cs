using Visitor_Security_Clearance_System.DTO;

namespace Visitor_Security_Clearance_System.Interface
{
    public interface IManagerService
    {
        Task<ManagerDTO> GetManagerByEmail(string Email);
        Task<ManagerDTO> RegisterManager(ManagerDTO managerDTO);

        Task<ManagerDTO> GetManagerByUId(string UId);

        Task<ManagerDTO> UpdateManager(ManagerDTO managerDTO);

        Task<string> DeleteManager(string UId);


    }
}
