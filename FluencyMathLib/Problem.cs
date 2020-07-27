using System;
using System.Collections.Generic;

namespace FluencyMathLib
{
    public class Problem
    {

        public List<int> Values { get; set; }
        public string Method { get; set; }

        public int Solution { get; private set; }
        public bool Result { get; private set; }

        public int Remainder { get; private set; }

        public Problem()
        {
            Result = false;
        }

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

        public void CreateAdditionProblem(int totalValues, int smallest, int largest)
        {
            Values = new List<int>();

            for (int i = 0; i < totalValues; i++)
            {
                var randomInt = generateRandomInt(smallest, largest);
                Values.Add(randomInt);
            }

            Method = "+";
            Create();
        }

        public void CreateSubtractionProblem(int totalValues, int smallest, int largest)
        {
            Values = new List<int>();



            for (int i = 0; i < totalValues; i++)
            {
                var randomInt = generateRandomInt(smallest, largest);
                Values.Add(randomInt);
            }

            if (Values.Count == 2 & Values[1] > Values[0])
            {
                // This is a jenky way to solve the problem of a random subtraction problem with a
                // first number that's less than the second (thus producing a negative number). A more
                // complete solution will have to be fleshed out when we make problems with more than 2 numbers.

                int larger = Values[1];
                Values[1] = Values[0];
                Values[0] = larger;
            }

            Method = "-";
            Create();
        }

        public void CreateMultiplicationProblem(int totalValues, int smallest, int largest)
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

        public void CreateDivisionProblem(int totalValues, int smallestFactor, int largestFactor, int smallestDivisor, int largestDivisor, bool remainders = false)
        {
            // Going to go out on a limb and say division problems with 3 values won't be an issue we have to face.

            // Make sure to set smallestDivisor to > 0

            // Need a way to make remainders into a variable that we can use outside of this method. Changes what inputs we ask for
            // and what values we calculate.

            Values = new List<int>();

            if (remainders)
            {
                int divisor = generateRandomInt(smallestDivisor, largestDivisor);

                var factors = new List<int>();

                for (int f = smallestFactor; f <= largestFactor; f++)
                {
                    factors.Add(f);
                }

                var random = new Random();
                int r = random.Next(factors.Count);
                int factor = factors[r];

                Values.Add(factor);
                Values.Add(divisor);
            }
            else
            {
                int divisor = generateRandomInt(smallestDivisor, largestDivisor);

                var factors = new List<int>();

                for (int f = smallestFactor; f <= largestFactor; f++)
                {
                    if (f % divisor == 0)
                    {
                        factors.Add(f);
                    }
                }

                var random = new Random();
                int r = random.Next(factors.Count);
                int factor = factors[r];

                Values.Add(factor);
                Values.Add(divisor);

            }

            Method = "/";
            Create();
        }

        private int generateRandomInt(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public void Answer(int inputAnswer)
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
    }
}
