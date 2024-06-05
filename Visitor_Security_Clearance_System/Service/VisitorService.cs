
using Visitor_Security_Clearance_System.Common;
using Visitor_Security_Clearance_System.CosmosDB;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Entity;
using Visitor_Security_Clearance_System.Interface;

namespace Visitor_Security_Clearance_System.Service
{
    public class VisitorService : IVisitorServicecs
    {
        public readonly ICosmosDBService _cosmosDBService;

        public VisitorService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }

         //Method to register visitor
        public async Task<VisitorDTO> RegisterVisitor(VisitorDTO visitorDTO)
        {
            VisitorEntity visitor = new VisitorEntity();
            visitor.Name = visitorDTO.Name;
            visitor.Email = visitorDTO.Email;
            visitor.PhoneNumber = visitorDTO.PhoneNumber;
            visitor.Address = visitorDTO.Address;
            visitor.CompanyName = visitorDTO.CompanyName;
            visitor.Purpose = visitorDTO.Purpose;
            visitor.EntryTime = visitorDTO.EntryTime;
            visitor.ExitTime = visitorDTO.ExitTime;
            visitor.Status = visitorDTO.Status;
            visitor.Role = visitorDTO.Role;



            visitor.Intialize(true, Credentials.VisitorDocumentType, "Pranjal", "Pranjal");

            //Add to DB
            var response = await _cosmosDBService.RegisterVisitor(visitor);

            var responseModel = new VisitorDTO();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;
            responseModel.Address = response.Address;
            responseModel.CompanyName = response.CompanyName;
            responseModel.Purpose = response.Purpose;
            responseModel.EntryTime = response.EntryTime;
            responseModel.ExitTime = response.ExitTime;
            responseModel.Status = response.Status;
            responseModel.Role = response.Role;

            return responseModel;
        }


      //Get by email
        public async Task<VisitorDTO> GetVisitorByEmail(string email)
        {
            var visitor = await _cosmosDBService.GetVisitorByEmail(email);
            if (visitor != null)
            {
                var visitorDTO = new VisitorDTO
                {
                    UId = visitor.UId,
                    Name = visitor.Name,
                    Email = visitor.Email,
                    PhoneNumber = visitor.PhoneNumber,
                    Address = visitor.Address,
                    CompanyName = visitor.CompanyName,
                    Purpose = visitor.Purpose,
                    EntryTime = visitor.EntryTime,
                    ExitTime = visitor.ExitTime,
                    Status = visitor.Status,
                    Role = visitor.Role,
                };
                return visitorDTO;
            }
            return null;
        }

        //Get by Uid
        public async Task<VisitorDTO> GetVisitorByUId(string UId)
        {
            var response = await _cosmosDBService.GetVisitorByUId(UId);

            var vistorDTO = new VisitorDTO();
            vistorDTO.UId = response.UId;
            vistorDTO.Name = response.Name;
            vistorDTO.Email = response.Email;
            vistorDTO.PhoneNumber = response.PhoneNumber;
            vistorDTO.Address = response.Address;
            vistorDTO.CompanyName = response.CompanyName;
            vistorDTO.Purpose = response.Purpose;
            vistorDTO.EntryTime = response.EntryTime;
            vistorDTO.ExitTime = response.ExitTime;
            vistorDTO.Status = response.Status;
            vistorDTO.Role = response.Role;

            return vistorDTO;
        }


        //update
        public async Task<VisitorDTO> UpdateVisitor(VisitorDTO visitorDTO)
        {
            var existingVisitor = await _cosmosDBService.GetVisitorByUId(visitorDTO.UId);
            existingVisitor.Active = false;
            existingVisitor.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingVisitor);

            existingVisitor.Intialize(false, Credentials.VisitorDocumentType, "Pranjal", "Pranjal");



            existingVisitor.UId = visitorDTO.UId;
            existingVisitor.Name = visitorDTO.Name;
            existingVisitor.Email = visitorDTO.Email;
            existingVisitor.PhoneNumber = visitorDTO.PhoneNumber;
            existingVisitor.Address = visitorDTO.Address;
            existingVisitor.CompanyName = visitorDTO.CompanyName;
            existingVisitor.Purpose = visitorDTO.Purpose;
            existingVisitor.EntryTime = visitorDTO.EntryTime;
            existingVisitor.ExitTime = visitorDTO.ExitTime;
            existingVisitor.Status = visitorDTO.Status;
            existingVisitor.Role= visitorDTO.Role;
            var response = await _cosmosDBService.RegisterVisitor(existingVisitor);

            var responseModel = new VisitorDTO
            {
              UId = response.UId,
            Name = response.Name,
            Email = response.Email,
            PhoneNumber = response.PhoneNumber,
            Address = response.Address,
            CompanyName = response.CompanyName,
            Purpose = response.Purpose,
            EntryTime = response.EntryTime,
            ExitTime = response.ExitTime,
            Status = response.Status,
            Role = response.Role,

        };
            return responseModel;


        }

        //delete
        public async Task<string> DeleteVisitor(string uId)
        {
            //geting visitor by uid
            var visitor = await _cosmosDBService.GetVisitorByUId(uId);
            visitor.Active = false;
            visitor.Archived = true;
            await _cosmosDBService.ReplaceAsync(visitor);

            visitor.Intialize(false, Credentials.VisitorDocumentType, "Pranjal", "Pranjal");
            visitor.Archived = true;
            var response = await _cosmosDBService.RegisterVisitor(visitor);

            return "Record Deleted Successfully";

        }

        public async Task<List<VisitorDTO>> GetVisitorsByStatus(string status)
        {
            // Fetching visitors 
            var visitor= await _cosmosDBService.GetVisitorsByStatus(status);

            // Mapping 
            var visitorlist = visitor.Select(visitor => new VisitorDTO
            {
                UId = visitor.UId,
                Email = visitor.Email,
                PhoneNumber = visitor.PhoneNumber,
                Address = visitor.Address,
                CompanyName = visitor.CompanyName,
                Purpose = visitor.Purpose,
                EntryTime = visitor.EntryTime,
                ExitTime = visitor.ExitTime,
                Status = visitor.Status,
                Role = visitor.Role,



            }).ToList();

            return visitorlist;
        }
    }
}
