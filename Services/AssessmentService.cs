using FluencyMath.Lib;
using System;
using System.Collections.Generic;


namespace FluencyMath.Services
{
    public class AssessmentService
    {

        public List<ProblemModel> Fetch(int numProblems)
        {
            return CreateFluencyAssessment(numProblems);
        }

        private List<ProblemModel> CreateFluencyAssessment(int numProblems)
        {
            var assessmentProblems = new List<ProblemModel>();

            for (int i = 0; i < numProblems; i++)
            {
                var assessmentProblem = CreateAdditionProblem(2, 0, 100);
                assessmentProblems.Add(assessmentProblem);
            }

            return assessmentProblems;
        }

        public List<ProblemModel> FetchByTypeId(Guid id)
        {
            var assessmentProblems = new List<ProblemModel>();

            //for (int i = 0; i < numProblems; i++)
            //{
            //    var assessmentProblem = CreateAdditionProblem(2, 0, 100);
            //    assessmentProblems.Add(assessmentProblem);
            //}

            return assessmentProblems;
        }

        public object Save(IEnumerable<ProblemModel> assessment)
        {



            throw new NotImplementedException();
        }

        /*
        public void Create()
        {

            if (Values.Count >= 2)
            {
                if (Method == "+")
                {
                    var solution = 0;

                    foreach (int value in Values)
                    {
                        solution = solution + value;
                    }

                    Solution = solution;
                }
                else if (Method == "-")
                {

                    var solution = Values[0];

                    for (int i = 1; i < Values.Count; i++)
                    {
                        solution = solution - Values[i];
                    }

                    Solution = solution;
                }
                else if (Method == "x")
                {

                    var solution = Values[0];

                    for (int i = 1; i < Values.Count; i++)
                    {
                        solution = solution * Values[i];
                    }

                    Solution = solution;
                }
                else if (Method == "/")
                {
                    // Again assuming no triple-valued division problems

                    Solution = Values[0] / Values[1];
                    Remainder = Values[0] % Values[1];
                }
                else
                {
                    throw new Exception("Problem Method is not valid");
                }
            }
            else
            {
                throw new Exception("Cannot create a problem without two or more values");
            }

        }
        */

        private Lib.ProblemModel CreateAdditionProblem(int totalValues, int smallest, int largest)
        {
            //Values = list of numbers we are adding together

            var problemModel = new Lib.ProblemModel();

            var addends = new List<int>();

            for (int i = 0; i < totalValues; i++)
            {
                var randomInt = generateRandomInt(smallest, largest);
                addends.Add(randomInt);
            }

            problemModel.Values = addends;
            problemModel.Method = "+";

            var solution = 0;

            foreach (int value in addends)
            {
                solution += value;
            }

            problemModel.Solution = solution;

            return problemModel;

        }

        private Lib.ProblemModel CreateSubtractionProblem(int totalValues, int smallest, int largest)
        {
            var problemModel = new Lib.ProblemModel();

            var toBeStubtracted = new List<int>();

            for (int i = 0; i < totalValues; i++)
            {
                var randomInt = generateRandomInt(smallest, largest);
                toBeStubtracted.Add(randomInt);
            }

            if (toBeStubtracted.Count == 2 && toBeStubtracted[1] > toBeStubtracted[0])
            {
                // This is a jenky way to solve the problem of a random subtraction problem with a
                // first number that's less than the second (thus producing a negative number). A more
                // complete solution will have to be fleshed out when we make problems with more than 2 numbers.

                int larger = toBeStubtracted[1];
                toBeStubtracted[1] = toBeStubtracted[0];
                toBeStubtracted[0] = larger;
            }

            problemModel.Values = toBeStubtracted;
            problemModel.Method = "-";

            var solution = toBeStubtracted[0];

            for (int i = 1; i < toBeStubtracted.Count; i++)
            {
                solution = solution - toBeStubtracted[i];
            }

            problemModel.Solution = solution;

            return problemModel;

        }

        /*private void CreateMultiplicationProblem(int totalValues, int smallest, int largest)
        {
            Values = new List<int>();

            for (int i = 0; i < totalValues; i++)
            {
                var randomInt = generateRandomInt(smallest, largest);
                Values.Add(randomInt);
            }

            Method = "x";
            Create();
        }

        private void CreateDivisionProblem(int smallest, int largest, bool remainders = false)
        {
            // Going to go out on a limb and say division problems with 3 values won't be an issue we have to face.

            // Make sure to set smallestDivisor to > 0

            // Need a way to make remainders into a variable that we can use outside of this method. Changes what inputs we ask for
            // and what values we calculate.

            Values = new List<int>();

            if (remainders)
            {
                int divisor = generateRandomInt(smallest, largest);
                int dividend = (divisor * generateRandomInt(smallest, largest)) + generateRandomInt(0, divisor);

                Values.Add(dividend);
                Values.Add(divisor);
            }
            else
            {
                int divisor = generateRandomInt(smallest, largest);
                int dividend = divisor * generateRandomInt(smallest, largest);

                Values.Add(dividend);
                Values.Add(divisor);

            }

            Method = "/";
            Create();
        }
        */

        private int generateRandomInt(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        private List<int> generateDigits(int num)
        {
            // Creates (reverse-ordered) list of integers where each integer is digit in input num

            var digits = new List<int>();
            while (num != 0)
            {
                int nextDigit = num % 10;
                num /= 10;
                digits.Add(nextDigit);
            }
            return digits;
        }

        private bool doesAdditionProblemCarry(List<int> numsAdded)
        {
            // digits1 is first number in addition problem

            var digitsOfNum1 = generateDigits(numsAdded[0]);
            var digitsOfNum2 = generateDigits(numsAdded[1]);

            for (int i = 0; i < Math.Min(digitsOfNum1.Count, digitsOfNum2.Count); i++)
            {
                if (digitsOfNum1[i] + digitsOfNum2[i] > 9)
                {
                    return true;
                }
            }
            return false;
        }

        private bool doesSubtractionProblemBorrow(List<int> numsSubtracted)
        {
            var digitsOfNum1 = generateDigits(numsSubtracted[0]);
            var digitsOfNum2 = generateDigits(numsSubtracted[1]);

            for (int i = 0; i < Math.Min(digitsOfNum1.Count, digitsOfNum2.Count); i++)
            {
                if (digitsOfNum1[i] < digitsOfNum2[i])
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * public void Answer(int inputAnswer)
        {
            if (Solution >= 0)
            {

                if (Solution == inputAnswer)
                {
                    Result = true;
                }

            }
            else
            {
                throw new Exception("A solution has not been created");
            }
        }
        */
        

    }
}
