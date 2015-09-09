namespace CodeRank.CSharpProblems.Ruleset.Base
{
    /// <summary>
    /// The ISampleTest interface provides an example of sample ruleset.
    /// </summary>
    public interface ISampleTest
    {
        /// <summary>
        /// This method will be the rule that will testified against some criterias for its provided implementations.
        /// </summary>
        /// <param name="a">
        /// First integer
        /// </param>
        /// <param name="b">
        /// Second integer
        /// </param>
        /// <returns>
        /// Result of addition of two supplied integers.
        /// </returns>
        int Sum(int a, int b);
    }
}
