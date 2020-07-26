using System;
using FluencyMathLib;

namespace FluencyMathConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var fluencyAssessment = new FluencyAssesment();

            fluencyAssessment.CreateFluencyAssessment();

            var message = string.Format("Your test will have {0} questions", fluencyAssessment.Questions.Count);
            Console.WriteLine(message);
        }
    }
}
