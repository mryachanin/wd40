using System;

namespace dotnet
{
    /* Each new term in the Fibonacci sequence is generated by adding the previous
       two terms. By starting with 1 and 2, the first 10 terms will be:

        1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

       By considering the terms in the Fibonacci sequence whose values do not exceed
       four million, find the sum of the even-valued terms.
    */
    public class Solution2
    {
        public SolutionStatus Status => SolutionStatus.Complete;

        public string Solve()
        {
            int prev = 1;
            int next = 2;
            long evenSum = 2;

            while (true)
            {
                int newNext = prev + next;
                prev = next;
                next = newNext;

                if (next >= 4000000)
                {
                    break;
                }

                if (next % 2 == 0)
                {
                    evenSum += next;
                }
            }

            return evenSum.ToString();
        }
    }
}