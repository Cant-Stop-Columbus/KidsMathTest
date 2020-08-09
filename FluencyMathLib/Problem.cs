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

        public void CreateDivisionProblem(int totalValues, int smallestDivisor, int largestDivisor, int smallestQuotient, int largestQuotient, bool remainders = false)
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

                for (int f = smallestQuotient; f <= largestQuotient; f++)
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

                Values[1] = generateRandomInt(smallestDivisor, largestDivisor);

                Values[0] = Values[1] * generateRandomInt(smallestQuotient, largestQuotient);

                /* Create Multiplication problem (1-9 x 1-9)

                values[0] = answer of multiplication prblen
                values[1] = values [0] of m problem
                answer = values[1] of m problem





                
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
                */

            }

            Method = "/";
            Create();
        }

        public void CreateTest01Problem()
        {
            CreateAdditionProblem(2, 0, 11);
        }

        public void CreateTest02Problem()
        {
            CreateSubtractionProblem(2, 0, 21);
        }

        public void CreateTest03Problem()
        {
            CreateAdditionProblem(2, 0, 100);
            while (doesAdditionProblemCarry(Values))
            {
                CreateAdditionProblem(2, 0, 100);
            }
        }

        public void CreateTest04Problem()
        {
            CreateAdditionProblem(2, 0, 100);
        }

        public void CreateTest05Problem()
        {
            CreateSubtractionProblem(2, 0, 100);
            while (doesSubtractionProblemBorrow(Values))
            {
                CreateSubtractionProblem(2, 0, 100);
            }
        }

        public void Create06Problem()
        {
            CreateSubtractionProblem(2, 0, 100);
        }

        public void Create07Problem()
        {
            CreateAdditionProblem(2, 0, 1000);
            while (doesAdditionProblemCarry(Values))
            {
                CreateAdditionProblem(2, 0, 1000);
            }
        }

        public void Create08Problem()
        {
            CreateAdditionProblem(2, 0, 1000);
        }

        public void Create09Problem()
        {
            CreateSubtractionProblem(2, 0, 1000);
            while (doesSubtractionProblemBorrow(Values))
            {
                CreateSubtractionProblem(2, 0, 1000);
            }
        }

        public void Create10Problem()
        {
            CreateSubtractionProblem(2, 0, 1000);
        }

        public void Create11Problem()
        {
            CreateMultiplicationProblem(2, 0, 10);
        }

        public void Create12Problem()
        {
            CreateDivisionProblem(2, 1, 82, 1, 10);
        }

        public void Create13Problem()
        {
            CreateMultiplicationProblem(2, 0, 12);
        }

        public void Create14Problem()
        {
            CreateDivisionProblem(2, 1, 145, 1, 13);
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
