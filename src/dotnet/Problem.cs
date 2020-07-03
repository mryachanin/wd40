namespace dotnet
{
    public interface Problem
    {
        /// <summary>
        /// The problem number correlated with Project Euler.
        /// </summary>
        int Number { get; }

        /// <summary>
        /// The current state of the solution.
        /// E.g. if the solution is complete or imcomplete.
        /// </summary>
        ProblemStatus Status { get; }

        /// <summary>
        /// Solve a given problem.
        /// </summary>
        string Solve();
    }
}