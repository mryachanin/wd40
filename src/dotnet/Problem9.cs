using System;

namespace dotnet
{
    /// <summary>
    /// A Pythagorean triplet is a set of three natural numbers, a < b < c,
    /// for which, a^2 + b^2 = c^2.
    ///
    /// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
    ///
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// </summary>
    public class Problem9 : Problem
    {
        public int Number => 9;

        public ProblemStatus Status => ProblemStatus.Solved;

        public string Solve()
        {
            int tripletSum = 1000;
            for (int a=1; a < tripletSum / 2; a++)
            {
                for (int b=a+1; b < tripletSum / 2; b++)
                {
                    double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    if (c % 1 == 0 && c > b && a + b + c == tripletSum)
                    {
                        Console.WriteLine("Pythagorean triplet found: a({0}), b({1}), c({2})", a, b, c);
                        return (a * b * c).ToString();
                    }
                }
            }

            return "No solution found";
        }
    }
}