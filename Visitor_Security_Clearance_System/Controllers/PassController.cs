using Microsoft.AspNetCore.Mvc;

using Visitor_Security_Clearance_System.Common;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Interface;


namespace Visitor_Security_Clearance_System.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PassController : Controller
    {
        private readonly IPassService _passService;

        public PassController(IPassService passService)
        {
            _passService = passService;
        }

        [HttpPost]
        public async Task<PassDTO> CreatePass(PassDTO passDTO)
        {

            var response = await _passService.CreatePass(passDTO);
            return response;
        }


        /*Method For Testing Purpose
       [HttpGet]
       public async Task<String> sendEmail()
       {
           var response = await _passService.SendDemo();
           return  response;
       }
       */


        [HttpPost("{uId}/status")]
        public async Task<ActionResult<PassDTO>> UpdatePassStatus(string uId, [FromBody] string newStatus)
        {
            var existingPass = await _passService.GetPassById(uId);

            if (existingPass == null)
            {
                return NotFound("Pass not found");
            }

            existingPass.Status = newStatus;

            var updatedPass = await _passService.UpdatePassStatus(uId, newStatus);

            return Ok(updatedPass);
        }




       








    }
}
