using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IAddUser addUser;
        private IGetUser getUser;
        public UserController(IAddUser _addUser, IGetUser _getUser)
        {
            addUser = _addUser;
            getUser = _getUser;
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            var data = getUser.GetUsers();

            if (data == null)
                return BadRequest(new { message = "Users data couldn`t get" });

            return Ok(data);
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(string id)
        {
            int userId = int.Parse(id);
            var data = getUser.GetUsers().Where(a=>a.Id== userId).ToList();

            if (data == null)
                return BadRequest(new { message = "Users data couldn`t get" });

            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody]User user)
        {
            bool retVal = addUser.AddUsers(user);

            if (retVal == false)
                return BadRequest(new { message = "Users dont add because application get some errors" });
            else
                return Ok(new { message = "Users add succesfully" });
        }

    }
}