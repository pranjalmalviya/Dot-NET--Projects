using Visitor_Security_Clearance_System.Common;
using Visitor_Security_Clearance_System.DTO;

namespace Visitor_Security_Clearance_System.Interface
{
    public interface IPassService
    {
        Task<PassDTO> CreatePass(PassDTO passDTO);
       // Task<String> SendDemo(); testind method

        Task<PassDTO> GetPassById(string uId);
        Task<PassDTO> UpdatePassStatus(string uId, string newStatus);



    }
}
