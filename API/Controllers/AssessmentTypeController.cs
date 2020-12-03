using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FluencyMath.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentTypeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var assessmentTypeService = new Services.AssessmentTypeService();

            var result = assessmentTypeService.Fetch();

            return Ok(result);

        }

    }
}