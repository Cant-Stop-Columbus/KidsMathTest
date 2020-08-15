using System;
using System.Collections.Generic;
using System.Linq;
using FluencyMath.Model;
using FluencyMathService;
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
            var prob1 = new ProblemModel()
            {
                Question = "1+1",
                Answer = "2"
            };

            var prob2 = new ProblemModel()
            {
                Question = "2+2",
                Answer = "3"
            };

            var problemList = new List<ProblemModel>();
            problemList.Add(prob1);
            problemList.Add(prob2);

            return Ok(problemList);

        }

        [HttpGet]
        [Route("/api/Hello")]
        public IActionResult GetHello()
        {
            var service = new ProblemService();
            var probe = service.Fetch(4);

            return Ok(probe);

        }

    }
}