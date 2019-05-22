using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core2_2ApiJwt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguauge languaugeData;
        public LanguageController(ILanguauge _languaugeData)
        {
            languaugeData = _languaugeData;
        }

        [HttpGet("GetLanguauge")]
        public IActionResult GetLanguauge()
        {
            var data = languaugeData.GetLanguage();

            if (data == null)
                return BadRequest(new { message = "Languauge data couldn`t get" });

            return Ok(data);
        }
    }
}