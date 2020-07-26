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
