using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FluencyMath.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var assessmentService = new Services.AssessmentService();

            var result = assessmentService.Fetch(20);

            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetByTypeId(Guid id)
        {
            var assessmentService = new Services.AssessmentService();

            var result = assessmentService.FetchByTypeId(id);

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post(IEnumerable<Lib.ProblemModel> assessment)
        {
            var assessmentService = new Services.AssessmentService();

            var result = assessmentService.Save(assessment);

            return Ok(result);

        }

        //[HttpPost]
        //public IActionResult Post()
        //{
        //    var assessmentService = new FluencyMathService.AssessmentService();
        //    var result = assessmentService.Fetch(20);

        //    return Ok(result);
        //}

    }
}