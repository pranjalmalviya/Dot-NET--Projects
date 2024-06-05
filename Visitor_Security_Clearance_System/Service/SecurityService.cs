using Microsoft.AspNetCore.Mvc;
using Visitor_Security_Clearance_System.Common;
using Visitor_Security_Clearance_System.CosmosDB;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Entity;
using Visitor_Security_Clearance_System.Interface;

namespace Visitor_Security_Clearance_System.Service
{
    public class SecurityService: ISecurityService
    {
        public readonly ICosmosDBService _cosmosDBService;

        public SecurityService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        [HttpPost]
        public async Task<SecurityDTO> RegisterSecurity(SecurityDTO securityDTO)
        {
            SecurityEntity security = new SecurityEntity();
            security.Name = securityDTO.Name;
            security.Email = securityDTO.Email;
            security.PhoneNumber = securityDTO.PhoneNumber;
            security.Role = securityDTO.Role;


            security.Intialize(true, Credentials.SecurityDocumentType, "Pranjal", "Pranjal");


            var response = await _cosmosDBService.RegisterSecurity(security);

            var responseModel = new SecurityDTO();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;
            responseModel.Role = response.Role;
           

            return responseModel;
        }
        public async Task<SecurityDTO> GetSecurityByEmail(string email)
        {
            var security = await _cosmosDBService.GetSecurityByEmail(email);
            if (security != null)
            {
                var securityDTO = new SecurityDTO
                {
                    UId = security.UId,
                    Name = security.Name,
                    Email = security.Email,
                    PhoneNumber = security.PhoneNumber,
                    Role = security.Role,
                };
                return securityDTO;
            }
            return null;
        }
        public async Task<SecurityDTO> GetSecurityByUId(string UId)
        {
            var response = await _cosmosDBService.GetSecurityByUId(UId);

            var securityDTO = new SecurityDTO();
            securityDTO.UId = response.UId;
            securityDTO.Name = response.Name;
            securityDTO.Email = response.Email;
            securityDTO.PhoneNumber = response.PhoneNumber;
            securityDTO.Role = response.Role;
           

            return securityDTO;
        }

        public async Task<SecurityDTO> UpdateSecurity(SecurityDTO securityDTO)
        {
            var existingSecurity = await _cosmosDBService.GetSecurityByUId(securityDTO.UId);
            existingSecurity.Active = false;
            existingSecurity.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingSecurity);

            existingSecurity.Intialize(false, Credentials.SecurityDocumentType, "Pranjal", "Pranjal");



            existingSecurity.UId = securityDTO.UId;
            existingSecurity.Name = securityDTO.Name;
            existingSecurity.Email = securityDTO.Email;
            existingSecurity.PhoneNumber = securityDTO.PhoneNumber;
            
            var response = await _cosmosDBService.RegisterSecurity(existingSecurity);

            var responseModel = new SecurityDTO
            {
                UId = response.UId,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.PhoneNumber,
                Role = response.Role,
                

            };
            return responseModel;


        }

        public async Task<string> DeleteSecurity(string uId)
        {
            //getting Security by uid
            var security = await _cosmosDBService.GetSecurityByUId(uId);
            security.Active = false;
            security.Archived = true;
            await _cosmosDBService.ReplaceAsync(security);

            security.Intialize(false, Credentials.SecurityDocumentType, "Pranjal", "Pranjal");
            security.Archived = true;

           

            var response = await _cosmosDBService.RegisterSecurity(security);

            return "Record Deleted Successfully";

        }
    }
}
