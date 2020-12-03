using System;
using System.Collections.Generic;

namespace FluencyMath.Lib
{
    public class ProblemModel
    {
        public List<int> Values { get; set; }
        public string Method { get; set; }
        public int Solution { get; set; }
        public int Answer { get; set; }
        public int AnswerRemainder { get; set; }
        public int Score { get; set; }
    }
}
