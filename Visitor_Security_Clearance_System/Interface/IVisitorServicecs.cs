using Visitor_Security_Clearance_System.DTO;

namespace Visitor_Security_Clearance_System.Interface
{
    public interface IVisitorServicecs
    {


        //Getting visitor by email
        Task<VisitorDTO> GetVisitorByEmail(string Email);

        //Register
        Task<VisitorDTO> RegisterVisitor(VisitorDTO visitorDTO);


        //retrive by uid
        Task<VisitorDTO> GetVisitorByUId(string UId);

        //update

        Task<VisitorDTO> UpdateVisitor(VisitorDTO visitorDTO);

        //delete

        Task<string> DeleteVisitor(string uId);

        //visitor as per status
        Task<List<VisitorDTO>> GetVisitorsByStatus(string status);
    }
}
