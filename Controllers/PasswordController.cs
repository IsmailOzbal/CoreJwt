using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PasswordController : ControllerBase
    {
        private readonly IPassword password;
        public PasswordController(IPassword _password)
        {
            password = _password;
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword([FromBody]Password pass)
        {
            bool retVal = password.Change(pass);

            if (retVal == false)
                return BadRequest(new { message = "User password dont change" });
            else
                return Ok(new { message = "Users password change succesfully" });
        }
    }
}