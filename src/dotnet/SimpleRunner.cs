using System;

namespace dotnet
{
    public sealed class SimpleRunner
    {
        static void Main()
        {
            RegisterProblems();
            RunProblem(ProblemRegistry.Instance.Latest());
        }

        private static void RegisterProblems()
        {
            ProblemRegistry registry = ProblemRegistry.Instance;
            registry.Register(new Problem1());
            registry.Register(new Problem2());
            registry.Register(new Problem3());
            registry.Register(new Problem4());
            registry.Register(new Problem5());
            registry.Register(new Problem6());
            registry.Register(new Problem7());
            registry.Register(new Problem8());
            registry.Register(new Problem9());
        }

        private static void RunProblem(Problem problem)
        {
            Console.WriteLine("Running problem number: {0}", problem.Number);

            DateTime start = DateTime.Now;
            Console.WriteLine("Solution: {0}", problem.Solve());
            DateTime end = DateTime.Now;
            Console.WriteLine("Execution took {0} seconds", (end - start).TotalSeconds);
        }
    }
}