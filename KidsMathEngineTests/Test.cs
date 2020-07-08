using KidsMathEngine;
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

    }
}
