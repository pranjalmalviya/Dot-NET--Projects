using Microsoft.AspNetCore.Mvc;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Interface;
using Visitor_Security_Clearance_System.Service;

namespace Visitor_Security_Clearance_System.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }
        [HttpPost]
        //Register
        public async Task<ActionResult<SecurityDTO>> RegisterSecurity(SecurityDTO securityDTO)
        {

            var existingSecurity = await _securityService.GetSecurityByEmail(securityDTO.Email);
            if (existingSecurity != null)
            {
                return Ok("Email already exist");
            }
            var response = await _securityService.RegisterSecurity(securityDTO);
            return response;
        }
        [HttpGet]
        //Get
        public async Task<SecurityDTO> GetSecurityByUId(string UId)
        {
            var response = await _securityService.GetSecurityByUId(UId);
            return response;
        }

        [HttpPost]
        //update
        public async Task<SecurityDTO> UpdateSecurity(SecurityDTO securityDTO)
        {
            var response = await _securityService.UpdateSecurity(securityDTO);
            return response;
        }

        [HttpPost]
        //delete
        public async Task<string> DeleteSecurity(string UId)
        {
            var response = await _securityService.DeleteSecurity(UId);
            return response;
        }

    }
}
