using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WordTypeController : ControllerBase
    {
        private readonly IWordType wordType;
        private readonly IAddWordType addWordType;
        public WordTypeController(IWordType _wordType, IAddWordType _addWordType)
        {
            wordType = _wordType;
            addWordType = _addWordType;
        }

        [HttpGet("GetWordType")]
        public IActionResult GetWordType()
        {
            var data = wordType.GetAll();

            if (data == null)
                return BadRequest(new { message = "Word type data couldn`t get" });

            return Ok(data);
        }

        [HttpPost("AddWordType")]
        public IActionResult AddWordType([FromBody]WordType type)
        {
            bool retVal = addWordType.Add(type);

            if (retVal == false)
                return BadRequest(new { message = "Word type dont add" });
            else
                return Ok(new { message = "Word type add succesfully" });
        }

    }
}