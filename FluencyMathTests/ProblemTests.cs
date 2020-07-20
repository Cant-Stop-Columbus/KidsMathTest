using FluencyMathLib;
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

        public void CanCreateRandomAdditionProblem()
        {
            //KidsMathEngine.Test test = new KidsMathEngine.Test();
            //var inputValues = new int[] { 10, 20 };
            var inputMethod = "+";

            var problem = new Problem
            {
                Method = inputMethod
            };

            problem.Create();

            Assert.IsNotNull(problem.Values);
            Assert.AreEqual(problem.Method, inputMethod);
            Assert.IsNotNull(problem.Solution);

        }

        [TestMethod]
        public void CanScoreCorrectAdditionProblem()
        {
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

    
            var sample_answer = 30;
            var sample_answer_str = sample_answer.ToString();
            var actual_answer_str = problem.Solution.ToString();

            if (sample_answer_str.Length != actual_answer_str.Length)
            {
                throw new System.Exception("Lengths are not the same");
            }

            var points_received = problem.Points;

            for (int i = 0; i < problem.Points; i++)
            {
                if (sample_answer_str[i] != actual_answer_str[i])
                {
                    points_received--;
                }

            }
            Assert.AreEqual(points_received, actual_answer_str.Length);
            Assert.AreEqual(30, problem.Solution);
            Assert.AreEqual(2, problem.Points);
        }

        [TestMethod]
        public void CanScoreWrongAdditionProblem()
        {
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

            
            var sample_answer = 20;
            var sample_answer_str = sample_answer.ToString().Split();
            var actual_answer_str = problem.Solution.ToString().Split();

            if (sample_answer_str.Length != actual_answer_str.Length)
            {
                throw new System.Exception("Lengths are not the same");
            }

            var points_received = problem.Points;
            var i = 0;

            foreach (var digit in sample_answer_str)
            {
                if (digit != actual_answer_str[i])
                {
                    points_received--;
                }
                i++;

            }
            Assert.AreEqual(points_received, problem.Points - 1);
            Assert.AreEqual(30, problem.Solution);
            Assert.AreEqual(2, problem.Points);
        }

    }
}
