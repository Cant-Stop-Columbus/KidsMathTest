using FluencyMathLib;
using FluencyMathService.Models;
using System;
using System.Collections.Generic;

namespace FluencyMathService
{
    public class ProblemService
    {

        public IList<ProblemModel> Fetch(int probeNumebr)
        {
            var prob1 = new ProblemModel()
            {
                Question = "3+3",
                Answer = "6"
            };

            var prob2 = new ProblemModel()
            {
                Question = "2+2",
                Answer = "3"
            };

            var problemList = new List<ProblemModel>();
            problemList.Add(prob1);
            problemList.Add(prob2);

            return problemList;
        }
      


    }
}
