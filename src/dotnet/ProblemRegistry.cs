using System.Collections.Generic;
using System.Linq;

namespace dotnet
{
    public sealed class ProblemRegistry
    {
        private static ProblemRegistry instance;
        private static readonly object instanceLock = new object();
        private Dictionary<int, Problem> registeredProblems = new Dictionary<int, Problem>();

        private ProblemRegistry() {}

        /// <summary>
        /// Obtain the single instance of this Problem Registry.
        /// </summary>
        public static ProblemRegistry Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProblemRegistry();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Register a given problem in the registry.
        /// </summary>
        public void Register(Problem problem)
        {
            registeredProblems.Add(problem.Number, problem);
        }

        public Problem Latest()
        {
            int latestProblem = registeredProblems.Keys.Max();
            return registeredProblems[latestProblem];
        }
    }
}