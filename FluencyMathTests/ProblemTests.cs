using FluencyMath.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace KidsMathEngineTests
{
    [TestClass]
    public class Test
    {

        [TestMethod]
        public void SampleTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CanCreateAdditionProblem()
        {

            //KidsMathEngine.Test test = new KidsMathEngine.Test();
            var inputValues = new List<int>();
            var inputMethod = "+";

            inputValues.Add(10);
            inputValues.Add(20);

            var problem = new Problem
            {
                Values = inputValues,
                Method = inputMethod
            };

            problem.Create();

            Assert.AreEqual(problem.Values, inputValues);
            Assert.AreEqual(problem.Method, inputMethod);
            Assert.AreEqual(problem.Solution, 30);

        }

        [TestMethod]
        public void CanCreateSubtractionProblem()
        {
            //KidsMathEngine.Test test = new KidsMathEngine.Test();
            var inputValues = new List<int>();
            var inputMethod = "-";

            inputValues.Add(25);
            inputValues.Add(10);

            var problem = new Problem
            {
                Values = inputValues,
                Method = inputMethod
            };

            problem.Create();


            //Assert.AreEqual(problem.Values, inputValues);
            Assert.AreEqual(problem.Method, inputMethod);
            Assert.AreEqual(problem.Solution, 15);

        }

        [TestMethod]
        public void CanCreateAdditionProblemandCorrectAnswer()
        {
            //KidsMathEngine.Test test = new KidsMathEngine.Test();
            var inputValues = new List<int>();
            var inputMethod = "+";
            var inputAnswer = 35;

            inputValues.Add(25);
            inputValues.Add(10);

            var problem = new Problem
            {
                Values = inputValues,
                Method = inputMethod,
            };

            problem.Create();
            problem.Answer(inputAnswer);

            Assert.AreEqual(problem.Method, inputMethod);
            Assert.AreEqual(problem.Solution, 35);
            Assert.AreEqual(problem.Result, true);

        }

        [TestMethod]
        public void CanCreateAdditionProblemandFalseAnswer()
        {
            //KidsMathEngine.Test test = new KidsMathEngine.Test();
            var inputValues = new List<int>();
            var inputMethod = "+";
            var inputAnswer = 30;

            inputValues.Add(25);
            inputValues.Add(10);

            var problem = new Problem
            {
                Values = inputValues,
                Method = inputMethod,
            };

            problem.Create();
            problem.Answer(inputAnswer);

            Assert.AreEqual(problem.Method, inputMethod);
            Assert.AreNotEqual(problem.Solution, 30);
            Assert.AreEqual(problem.Result, false);

        }

        [TestMethod]
        public void CanCreateRandomAdditionProblem()
        {
            //KidsMathEngine.Test test = new KidsMathEngine.Test();
            //var inputValues = new int[] { 10, 20 };
            var inputMethod = "+";
            var inputValues = new List<int>();
            //var inputAnswer = 30;

            inputValues.Add(25);
            inputValues.Add(10);
            var problem = new Problem
            {
                Method = inputMethod,
                Values = inputValues,
            };

            problem.Create();

            var testAnswer = 200;

            foreach(var digit in testAnswer.ToString().Split())
            {
                var test = digit;
            }


            Assert.IsNotNull(problem.Values);
            Assert.AreEqual(problem.Method, inputMethod);
            Assert.IsNotNull(problem.Solution);

        }

        [TestMethod]
        public void CanCreateDivisionProblem()
        {
            var inputValues = new List<int>();
            var inputMethod = "/";
            var inputAnswer = 3;

            inputValues.Add(9);
            inputValues.Add(3);

            var problem = new Problem
            {
                Values = inputValues,
                Method = inputMethod,
            };

            problem.Create();
            problem.Answer(inputAnswer);

            Assert.AreEqual(problem.Values, inputValues);
            Assert.AreEqual(problem.Method, inputMethod);
            Assert.AreEqual(problem.Solution, 3);


        }

        [TestMethod]
        public void CanCreateDivisionProblemWithCorrectAnswer()
        {
            var inputValues = new List<int>();
            var inputMethod = "/";
            var inputAnswer = 9;

            inputValues.Add(81);
            inputValues.Add(9);

            var problem = new Problem
            {
                Values = inputValues,
                Method = inputMethod,
            };

            problem.Create();
            problem.Answer(inputAnswer);

            Assert.AreEqual(problem.Values, inputValues);
            Assert.AreEqual(problem.Method, inputMethod);
            Assert.AreEqual(problem.Solution, 9);
        }

        [TestMethod]
        public void CanCreateDivisionProblemWithFalseAnswer()
         {
                //KidsMathEngine.Test test = new KidsMathEngine.Test();
                var inputValues = new List<int>();
                var inputMethod = "/";
                var inputAnswer = 8;

                inputValues.Add(81);
                inputValues.Add(9);

                var problem = new Problem
                {
                    Values = inputValues,
                    Method = inputMethod,
                };

                problem.Create();
                problem.Answer(inputAnswer);

                Assert.AreEqual(problem.Method, inputMethod);
                Assert.AreNotEqual(problem.Solution, 8);
                Assert.AreEqual(problem.Result, false);

          }

        [TestMethod]
        public void CanDetermineIfDivisionProblemHasARemainder()
        {
            var inputValues = new List<int>();
            var inputMethod = "/";
            var inputAnswer = 10;
         

            inputValues.Add(81);
            inputValues.Add(8);

            var problem = new Problem
            {
                Values = inputValues,
                Method = inputMethod,
            };
            problem.Create();
            problem.Answer(inputAnswer);

            Assert.AreEqual(problem.Method, inputMethod);
            Assert.AreEqual(problem.Remainder, 1);
            Assert.AreEqual(problem.Solution, 10);

        }

        
        /*
        [TestMethod]
        public void CanCreateDivisionProblemWithoutRemainders()
        {
            var problem = new Problem;
            problem.CreateDivisionProblem(2, 1, 10, 1, 10);

            Assert.IsNotNull(problem.Values);
        }
        
        
        
        [TestMethod]
        public void CanCreate2_1_ProblemWithTwoPositiveValues()
        {
            var problem = new Problem();
            problem.Create2_1_Problem();

            Assert.AreEqual(problem.Values.Count, 2);
            // sum(values) = answer
            Assert.AreEqual(problem.Values[0] + problem.Values[1], problem.Solution);
            // each value not > 10
            Assert.AreEqual(problem.Values[0] <= 10, true);
            Assert.AreEqual(problem.Values[1] <= 10, true);
            // each value not < 0
            Assert.AreEqual(problem.Values[0] >= 0, true);
            Assert.AreEqual(problem.Values[1] >= 0, true);
            // answer not > 20
            Assert.AreEqual(problem.Solution <= 20, true);

        }
        */
    }
}
