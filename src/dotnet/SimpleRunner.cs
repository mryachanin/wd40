using System;

namespace dotnet
{
    public class SimpleRunner
    {
        static void Main()
        {
            DateTime start = DateTime.Now;
            Console.WriteLine(new Solution3().Solve());
            DateTime end = DateTime.Now;
            Console.WriteLine("Execution took {0} seconds", (end - start).TotalSeconds);
        }
    }
}