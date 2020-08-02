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

            if (Values.Count == 2 && Values[1] > Values[0])
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

        public void CreateDivisionProblem(int totalValues, int smallestDivisor, int largestDivisor, int smallestFactor, int largestFactor, bool remainders = false)
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

        public void Create2_1_Problem()
        {
            CreateAdditionProblem(2, 0, 11);
        }

        public void Create2_5_Problem()
        {
            CreateSubtractionProblem(2, 0, 21);
        }

        public void Create2_8_Problem()
        {
            CreateAdditionProblem(2, 0, 100);
            while (doesAdditionProblemCarry(Values))
            {
                CreateAdditionProblem(2, 0, 100);
            }
        }

        public void Create2_9_Problem()
        {
            CreateAdditionProblem(2, 0, 100);
        }

        public void Create2_10_Problem()
        {
            CreateSubtractionProblem(2, 0, 100);
            while (doesSubtractionProblemBorrow(Values))
            {
                CreateSubtractionProblem(2, 0, 100);
            }
        }

        private int generateRandomInt(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        private List<int> generateDigits(int num)
        {
            // Creates (reverse-ordered) list of integers where each integer is digit in input num

            var digits = new List<int>();
            while(num != 0)
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

            for(int i = 0; i < Math.Min(digitsOfNum1.Count, digitsOfNum2.Count); i++)
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

            for(int i = 0; i < Math.Min(digitsOfNum1.Count, digitsOfNum2.Count); i++)
            {
                if (digitsOfNum1[i] < digitsOfNum2[i])
                {
                    return true;
                }
            }
            return false;
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
