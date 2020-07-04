using System.Collections.Generic;

namespace dotnet
{
    /// <summary>
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13,
    /// we can see that the 6th prime is 13.
    ///
    /// What is the 10,001st prime number?
    /// </summary>
    public class Problem7 : Problem
    {
        public int Number => 7;

        public ProblemStatus Status => ProblemStatus.Solved;

        public string Solve()
        {
            return FindNthPrime(10001).ToString();
        }

        /// <summary>
        /// Finds the Nth prime number.
        /// </summary>
        private long FindNthPrime(int primeIndex)
        {
            HashSet<long> knownPrimes = new HashSet<long> { 2 };
            int currentPrimeIndex = 1;
            long lastPrime = 2;

            for (int i=3; currentPrimeIndex < primeIndex; i+=2)
            {
                if (IsPrimeUsingMod(knownPrimes, i))
                {
                    currentPrimeIndex++;
                    lastPrime = i;
                    knownPrimes.Add(i);
                }
            }

            return lastPrime;
        }

        /// <summary>
        /// Determines if a given number is prime by seeing if any known
        /// primes are a factor.
        ///
        /// This assumes that all primes lower than the given number have been
        /// found already.
        /// </summary>
        private bool IsPrimeUsingMod(HashSet<long> knownPrimes, int num)
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
    }
}