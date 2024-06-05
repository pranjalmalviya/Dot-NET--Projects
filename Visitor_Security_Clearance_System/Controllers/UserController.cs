using Microsoft.AspNetCore.Mvc;
using Visitor_Security_Clearance_System.DTO;
using Visitor_Security_Clearance_System.Interface;


namespace Visitor_Security_Clearance_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost("login")]
         public async Task<ActionResult<UserLoginDTO>> Login([FromBody] UserLoginDTO loginRequest)
         {
             try
             {
                 var userLoginDTO = await _authService.Authenticate(loginRequest.Email);

                 if (userLoginDTO != null)
                 {
                     // Checking role matching in the role in the database
                     if (userLoginDTO.Role == loginRequest.Role)
                     {
                         return Ok(new { message = "Login successful" });
                     }
                     else
                     {
                         // creating anonymous object to for holding response
                         return Unauthorized(new { message = "Invalid role" });
                     }
                 }
                 else
                 {
                     return Unauthorized(new { message = "Invalid credentials" });
                 }
             }
             catch (Exception ex)
             {
                 return StatusCode(500, new { message = "An error occurred " });
             }
         }





        /*  [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            
            var user = await _authService.GetUserAsync(model.UId, model.Email, model.Role);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            DateTime loggedTime = DateTime.Now;
           
            if (loggedTime.AddMinutes(15) < DateTime.Now)
            {
                throw new Exception("Session Expired");
            }
            // else
            //{

            // var userLoginDTO = await _authService.Authenticate(model.Role);

            //  return Ok(userLoginDTO);
            //}
            return null;
        }*/
    }
}
