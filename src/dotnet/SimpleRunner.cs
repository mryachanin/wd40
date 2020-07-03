using System;

namespace dotnet
{
    public class SimpleRunner
    {
        static void Main()
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("Solution: {0}", new Solution4().Solve());
            DateTime end = DateTime.Now;
            Console.WriteLine("Execution took {0} seconds", (end - start).TotalSeconds);
        }
    }
}