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

        [TestMethod]
        public void CanCreateRandomAdditionProblem()
        {
            //KidsMathEngine.Test test = new KidsMathEngine.Test();
            //var inputValues = new int[] { 10, 20 };
            var inputMethod = "+";
            var inputValues = new List<int>();
            var inputAnswer = 30;

            inputValues.Add(25);
            inputValues.Add(10);
            var problem = new Problem
            {
                Method = inputMethod
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

    }
}
