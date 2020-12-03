using System;
using FluencyMath.Lib;

namespace FluencyMathConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fluencyAssessment = new FluencyAssesment_old();

            fluencyAssessment.CreateFluencyAssessment();

            var message = string.Format("Your test will have {0} questions", fluencyAssessment.Questions.Count);
            Console.WriteLine(message);

            fluencyAssessment.DisplayProblem();
        }
    }
}
