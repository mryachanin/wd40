using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    ///
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class Solution3
    {
        public SolutionStatus Status => SolutionStatus.Complete;

        public string Solve()
        {
            long composite = 600851475143;

            DateTime start = DateTime.Now;
            HashSet<long> knownPrimeFactors = FindLowerPrimes(composite);
            DateTime end = DateTime.Now;
            Console.WriteLine("Found lower primes in {0} seconds", (end - start).TotalSeconds);

            start = DateTime.Now;
            knownPrimeFactors = FindHigherPrimes(knownPrimeFactors, composite);
            end = DateTime.Now;
            Console.WriteLine("Found higher primes in {0} seconds", (end - start).TotalSeconds);

            return knownPrimeFactors.Max().ToString();
        }

        /// <summary>
        /// Finds the prime factors less-than or equal-to the square root of
        /// the given composite number.
        /// </summary>
        private HashSet<long> FindLowerPrimes(long composite)
        {
            HashSet<long> knownPrimes = new HashSet<long> { 2 };
            HashSet<long> knownPrimeFactors = new HashSet<long>();

            // Special case even numbers up front. Only prime factor will be 2.
            if ((composite & 1) == 0)
            {
                knownPrimeFactors.Add(2);
            }

            // The composite cannot consist of 2 prime factors greater than
            // the square root of the composite. Therefore, only search up to
            // that point.
            // Since 2 was already taken care of, start at 3 and count by 2.
            for (int i=3; i <= Math.Sqrt(composite); i+=2)
            {
                if (IsPrimeUsingMod(knownPrimes, i))
                {
                    knownPrimes.Add(i);

                    if (IsFactor(i, composite))
                    {
                        Console.WriteLine("New Prime: {0}", i);
                        knownPrimeFactors.Add(i);
                    }
                }
            }

            return knownPrimeFactors;
        }

        /// <summary>
        /// Finds the prime factor (if any) that is greater-than the square
        /// root of the given composite.
        /// </summary>
        private HashSet<long> FindHigherPrimes(HashSet<long> knownPrimeFactors, long composite)
        {
            // A prime factor (if exists) greater than the square root of the
            /// composite will stand alone; multiplied with n-many factors less
            /// than the square root.
            // This is due to the fact that: composite = sqrt(composite)^2
            // E.g. 100 = 10^2, which means (10+1)^2 is by definition greater.
            //
            // Do a simple find of such larger factor by iteratively dividing
            // the composite by all factors less than the square-root.
            long newFind = composite;
            foreach (long factor in knownPrimeFactors)
            {
                while (IsFactor(factor, newFind))
                {
                    newFind /= factor;
                }
            }

            // 1 means all of the prime factors are less than or equal to the
            // square root of the composite.
            if (newFind != 1 && knownPrimeFactors.Add(newFind))
            {
                Console.WriteLine("New Prime: {0}", newFind);
            }

            return knownPrimeFactors;
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

        /// <summary>
        /// Determines if the given number is a factor of the given composite.
        ///
        /// A number is a factor of a composite if it fits into the composite
        /// some round number of times. E.g. 10 is a factor of 20 because it
        /// fits into 20 2 times.
        /// </summary>
        private bool IsFactor(long num, long composite)
        {
            return composite % num == 0;
        }
    }
}