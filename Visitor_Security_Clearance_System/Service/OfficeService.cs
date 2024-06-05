using Microsoft.AspNetCore.Mvc;
using Visitor_Security_Clearance_System.Common;
using Visitor_Security_Clearance_System.CosmosDB;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Entity;
using Visitor_Security_Clearance_System.Interface;

namespace Visitor_Security_Clearance_System.Service
{
    public class OfficeService : IOfficeService
    {
        public readonly ICosmosDBService _cosmosDBService;

        public OfficeService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        [HttpPost]
        public async Task<OfficeDTO> RegisterOffice(OfficeDTO officeDTO)
        {
            OfficeEntity office = new OfficeEntity();
            office.UId = officeDTO.UId;
            office.Name = officeDTO.Name;
            office.Location = officeDTO.Location;
            office.ManagerId = officeDTO.ManagerId;


            office.Intialize(true, Credentials.OfficeDocumentType, "Pranjal", "Pranjal");


            var response = await _cosmosDBService.RegisterOffice(office);

            var responseModel = new OfficeDTO();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Location = response.Location;
            responseModel.ManagerId = response.ManagerId;


            return responseModel;
        }
        public async Task<OfficeDTO> GetOfficeByUId(string UId)
        {
            var response = await _cosmosDBService.GetOfficeByUId(UId);

            var officeDTO = new OfficeDTO();
            officeDTO.UId = response.UId;
            officeDTO.Name = response.Name;
            officeDTO.Location = response.Location;
            officeDTO.ManagerId = response.ManagerId;


            return officeDTO;
        }
        public async Task<OfficeDTO> UpdateOffice(OfficeDTO officeDTO)
        {
            var existingOffice= await _cosmosDBService.GetOfficeByUId(officeDTO.UId);
            existingOffice.Active = false;
            existingOffice.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingOffice);

            existingOffice.Intialize(false, Credentials.OfficeDocumentType, "Pranjal", "Pranjal");



            existingOffice.UId = officeDTO.UId;
            existingOffice.Name = officeDTO.Name;
            existingOffice.Location = officeDTO.Location;
            existingOffice.ManagerId = officeDTO.ManagerId;

            var response = await _cosmosDBService.RegisterOffice(existingOffice);

            var responseModel = new OfficeDTO
            {
                UId = response.UId,
                Name = response.Name,
               Location = officeDTO.Location,
              ManagerId = officeDTO.ManagerId,



        };
            return responseModel;


        }

        public async Task<string> DeleteOffice(string uId)
        {//getoffice by id
            
            var office = await _cosmosDBService.GetOfficeByUId(uId);
            office.Active = false;
            office.Archived = true;
            await _cosmosDBService.ReplaceAsync(office);

            office.Intialize(false, Credentials.OfficeDocumentType, "Pranjal", "Pranjal");
            office.Archived = true;


            var response = await _cosmosDBService.RegisterOffice(office);

            return "Record Deleted Successfully";

        }
    }
}
