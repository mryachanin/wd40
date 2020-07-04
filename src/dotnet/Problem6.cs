using System;

namespace dotnet
{
    /// <summary>
    /// The sum of the squares of the first ten natural numbers is,
    ///  12+22+...+102=385
    ///
    /// The square of the sum of the first ten natural numbers is,
    ///  (1+2+...+10)2=552=3025
    ///
    /// Hence the difference between the sum of the squares of the first ten
    /// natural numbers and the square of the sum is 3025−385=2640.
    ///
    /// Find the difference between the sum of the squares of the first one
    /// hundred natural numbers and the square of the sum.
    /// </summary>
    public class Problem6 : Problem
    {
        public int Number => 6;

        public ProblemStatus Status => ProblemStatus.Solved;

        public string Solve()
        {
            long sumOfSquares = 0;
            long squareOfSum = 0;
            long runningSum = 0;
            for (int i=1; i <= 100; i++)
            {
                sumOfSquares += (long)Math.Pow(i, 2);
                runningSum += i;
            }

            squareOfSum = (long)Math.Pow(runningSum, 2);
            Console.WriteLine("Sum of Squares: {0}, Square of Sum: {1}", sumOfSquares, squareOfSum);

            return (squareOfSum - sumOfSquares).ToString();
        }
    }
}