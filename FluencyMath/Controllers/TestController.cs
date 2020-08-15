using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FluencyMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var assessmentService = new FluencyMathService.AssessmentService();

            var result = assessmentService.Fetch(20);

            return Ok(result);

        }

    }
}