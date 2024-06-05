using Microsoft.AspNetCore.Mvc;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Interface;
using Visitor_Security_Clearance_System.Service;

namespace Visitor_Security_Clearance_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpPost]
        public async Task<OfficeDTO> RegisterOffice(OfficeDTO officeDTO)
        {

            var response = await _officeService.RegisterOffice(officeDTO);
            return response;
        }
        [HttpGet]

        public async Task<OfficeDTO> GetOfficeByUId(string UId)
        {
            var response = await _officeService.GetOfficeByUId(UId);
            return response;
        }

        [HttpPost]
        public async Task<OfficeDTO> UpdateOffice(OfficeDTO officeDTO)
        {
            var response = await _officeService.UpdateOffice(officeDTO);
            return response;
        }

        [HttpPost]
        public async Task<string> DeleteOffice(string UId)
        {
            var response = await _officeService.DeleteOffice(UId);
            return response;
        }
    }
}
