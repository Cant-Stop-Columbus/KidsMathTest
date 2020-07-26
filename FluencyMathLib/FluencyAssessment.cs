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

        public FluencyAssesment()
        {
            Score = 0;
           // timer = new System.Timers.Timer(1000);
           // timer.Enabled = true;

        }
        public void CreateFluencyAssessment()
        {
            
            for ( int i = 0; i < 20; i++)
            {
                 Problem P = new Problem();
                P.CreateAdditionProblem(2, 0, 10);
                Questions.Add(P);

            }
        }
       
      


        
        }
    
}

    