using System.Collections.Generic;
using System.Linq;

namespace dotnet
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers
    /// from 1 to 10 without any remainder.
    ///
    /// What is the smallest positive number that is evenly divisible by all
    /// of the numbers from 1 to 20?
    /// </summary>
    public class Problem5 : Problem
    {
        public int Number => 5;

        public ProblemStatus Status => ProblemStatus.Solved;

        public string Solve()
        {
            List<int> divisors = new List<int>();

            for (int i=2; i < 20; i++)
            {
                divisors.Add(i);
            }

            // Start with 20 and check divisor list against all multiples.
            // This computes the fastest as 20 grows multiples the quickest.
            int baseDivisor = 20;
            int composite = baseDivisor;
            for (int i=2; !AllAreDivisors(divisors, composite); i++)
            {
                composite = baseDivisor * i;
            }

            return composite.ToString();
        }

        private bool AllAreDivisors(List<int> divisors, int composite)
        {
            return divisors.All(divisor => composite % divisor == 0);
        }
    }
}