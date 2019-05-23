using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WordDescriptionController : ControllerBase
    {
        private readonly IAddWordDescription addWordDesc;
        public WordDescriptionController(IAddWordDescription _addWordDesc)
        {
            addWordDesc = _addWordDesc;
        }

        [HttpPost("AddWordDescription")]
        public IActionResult AddWordDescription([FromBody]WordDescription wordDesc)
        {
            bool retVal = addWordDesc.Add(wordDesc);

            if (retVal == false)
                return BadRequest(new { message = "Word description dont add because application get some errors" });
            else
                return Ok(new { message = "Words description add succesfully" });
        }
    }
}