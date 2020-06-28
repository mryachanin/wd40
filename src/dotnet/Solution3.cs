using System;
using System.Collections.Generic;

namespace dotnet
{
    /* The prime factors of 13195 are 5, 7, 13 and 29.

       What is the largest prime factor of the number 600851475143 ?
    */
    public class Solution3
    {
        public SolutionStatus Status => SolutionStatus.Incomplete;

        public string Solve()
        {
            long composite = 600851475143;

            List<long> knownPrimes = new List<long>();
            int longestPrimeFactor = 1;
            int count = 0;

            long breakpoint = composite;
            for (int i=3; i <= breakpoint; i+=2)
            {
                if (++count > 100000) {
                    Console.WriteLine("100k computed. On: {0}", i);
                    count = 0;
                }

                if (IsPrimeUsingMod(knownPrimes, i))
                {
                    knownPrimes.Add(i);

                    if (IsFactor(i, composite))
                    {
                        longestPrimeFactor = i;
                        breakpoint = composite / i;

                        Console.WriteLine("New Prime: {0}, Breakpoint: {1}", i, breakpoint);
                    }
                }
            }

            return longestPrimeFactor.ToString();
        }
        
        private bool IsPrimeUsingMod(List<long> knownPrimes, int num)
        {
            foreach (long p in knownPrimes)
            {
                if (num % p == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsFactor(int num, long composite)
        {
            return composite % num == 0;
        }
    }
}