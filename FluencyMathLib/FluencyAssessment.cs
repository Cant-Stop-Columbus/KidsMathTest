using System;
using System.Collections.Generic;
using System.Timers;

namespace FluencyMathLib
{

    public class FluencyAssesment : Problem
    {
        public List<Problem> Questions { get; set; }
        public int Score { get; private set; }
        public static Timer timer;

        public void CreateFluencyAssessment()
        {
            Questions = new List<Problem>();
            Score = 0;

            for ( int i = 0; i < 20; i++)
            {
                Problem problem = new Problem();
                problem.CreateAdditionProblem(2, 0, 10);
                Questions.Add(problem);
            }
        }

        public void DisplayProblem()
        {
            
        }

    }
    
}

    