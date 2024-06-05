using Microsoft.AspNetCore.Mvc;
using Visitor_Security_Clearance_System.Common;
using Visitor_Security_Clearance_System.CosmosDB;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Entity;
using Visitor_Security_Clearance_System.Interface;

namespace Visitor_Security_Clearance_System.Service
{
    public class ManagerService : IManagerService
    {
        public readonly ICosmosDBService _cosmosDBService;

        public ManagerService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }

        [HttpPost]

        //Register
        public async Task<ManagerDTO> RegisterManager(ManagerDTO managerDTO)
        {
            ManagerEntity manager= new ManagerEntity();
            manager.UId = managerDTO.UId;
            manager.Name = managerDTO.Name;
            manager.Email = managerDTO.Email;
            manager.PhoneNumber = managerDTO.PhoneNumber;
            manager.Role= managerDTO.Role;


            manager.Intialize(true, Credentials.ManagerDocumentType, "Pranjal", "Pranjal");


            var response = await _cosmosDBService.RegisterManager(manager);

            var responseModel = new ManagerDTO();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;
            responseModel.Role = response.Role;


            return responseModel;
        }

        public async Task<ManagerDTO> GetManagerByEmail(string email)
        {
            var manager = await _cosmosDBService.GetManagerByEmail(email);
            if (manager != null)
            {
                var managerDTO = new ManagerDTO
                {
                    UId = manager.UId,
                    Name = manager.Name,
                    Email = manager.Email,
                    PhoneNumber = manager.PhoneNumber,
                    Role = manager.Role,
                };
                return managerDTO;
            }
            return null;
        }

        //get by uid
        public async Task<ManagerDTO> GetManagerByUId(string UId)
        {
            var response = await _cosmosDBService.GetManagerByUId(UId);

            var managerDTO = new ManagerDTO();
            managerDTO.UId = response.UId;
            managerDTO.Name = response.Name;
            managerDTO.Email = response.Email;
            managerDTO.PhoneNumber = response.PhoneNumber;
            managerDTO.Role = response.Role;


            return managerDTO;
        }

        //update
        public async Task<ManagerDTO> UpdateManager(ManagerDTO managerDTO)
        {
            var existingManager = await _cosmosDBService.GetManagerByUId(managerDTO.UId);
            existingManager.Active = false;
            existingManager.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingManager);

            existingManager.Intialize(false, Credentials.ManagerDocumentType, "Pranjal", "Pranjal");



            existingManager.UId = managerDTO.UId;
            existingManager.Name = managerDTO.Name;
            existingManager.Email = managerDTO.Email;
            existingManager.PhoneNumber = managerDTO.PhoneNumber;
            existingManager.Role = managerDTO.Role;

            var response = await _cosmosDBService.RegisterManager(existingManager);

            var responseModel = new ManagerDTO
            {
                UId = response.UId,
                Name = response.Name,
                Email = response.Email,
                PhoneNumber = response.PhoneNumber,
                Role = response.Role,


            };
            return responseModel;


        }

        public async Task<string> DeleteManager(string uId)
        {
            //getting manager by uid
            var manager = await _cosmosDBService.GetManagerByUId(uId);
            manager.Active = false;
            manager.Archived = true;
            await _cosmosDBService.ReplaceAsync(manager);

            manager.Intialize(false, Credentials.ManagerDocumentType, "Pranjal", "Pranjal");
            manager.Archived = true;

            var response = await _cosmosDBService.RegisterManager(manager);

            return "Record Deleted Successfully";

        }
    }

}

