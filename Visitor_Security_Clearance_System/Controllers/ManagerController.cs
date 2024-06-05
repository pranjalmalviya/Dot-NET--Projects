using Microsoft.AspNetCore.Mvc;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Interface;
using Visitor_Security_Clearance_System.Service;

namespace Visitor_Security_Clearance_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        //Register
        public async Task<ActionResult<ManagerDTO>> RegisterManager(ManagerDTO managerDTO)
        {
            //Checking Manager already has account  
            var existingManager = await _managerService.GetManagerByEmail(managerDTO.Email);
            if (existingManager != null)
            {
                return Ok("Email already exist");
            }
            var response = await _managerService.RegisterManager(managerDTO);
            return response;
        }
        [HttpGet]


        //Get by uid
        public async Task<ManagerDTO> GetManagerByUId(string UId)
        {
            var response = await _managerService.GetManagerByUId(UId);
            return response;
        }

        [HttpPost]
        //update
        public async Task<ManagerDTO> UpdateManager(ManagerDTO managerDTO)
        {
            var response = await _managerService.UpdateManager(managerDTO);
            return response;
        }
        //delete

        [HttpPost]
        public async Task<string> DeleteManager(string UId)
        {
            var response = await _managerService.DeleteManager(UId);
            return response;
        }
    }
}
