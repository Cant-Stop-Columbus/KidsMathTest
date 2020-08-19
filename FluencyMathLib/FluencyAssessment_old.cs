using System;
using System.Collections.Generic;
using System.Timers;

namespace FluencyMathLib
{

    public class FluencyAssesment_old : Problem
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
                problem.Create12Problem();
                Questions.Add(problem);
            }
        }

        public void DisplayProblem()
        {
            foreach(var question in Questions)
            {
                var askQuestion = string.Format("{0} {1} {2}",question.Values[0], question.Method, question.Values[1]);
                Console.WriteLine(askQuestion);

                var answer = Console.ReadLine();

                try
                {
                    int numericAnswer = int.Parse(answer);
                    question.Answer(numericAnswer);

                    if (question.Result)
                    {
                        Console.WriteLine("Good Job!");
                    }
                    else
                    {
                        Console.WriteLine("Maybe next time...");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid answer");
                }
              
            }
            
        }

    }
    
}

    