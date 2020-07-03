using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome
    /// made from the product of two 2-digit numbers is 9009 = 91 × 99.
    ///
    /// Find the largest palindrome made from the product of two 3-digit
    /// numbers.
    /// </summary>
    public class Solution4
    {
        public SolutionStatus Status => SolutionStatus.Complete;

        public string Solve()
        {
            HashSet<int> palindromes = new HashSet<int>();
            for (int leader=999; leader > 100; leader --)
            {
                for (int follower=999; follower >= 100; follower--)
                {
                    int next = leader * follower;
                    if (IsPalindrome(next))
                    {
                        palindromes.Add(next);
                    }
                }
            }

            return palindromes.Count > 0 ?
                palindromes.Max().ToString() :
                "No palindrome found.";
        }

        /// <summary>
        /// Checks if a given number is a palindrome.
        /// </summary>
        private bool IsPalindrome(int num)
        {
            char[] numAsChar = num.ToString().ToCharArray();
            for (int i=0; i < Math.Floor((double)numAsChar.Length / 2); i++)
            {
                if (numAsChar[i] != numAsChar[numAsChar.Length-i-1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}