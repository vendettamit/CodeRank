using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Api.Entities;

namespace CodeRank.Compiler.Base
{
    /// <summary>
    /// Provides the methods for running the given tests against the source assembly.
    /// </summary>
    public interface ICustomTestRunner
    {
        /// <summary>
        /// Runs the test in given assembly against the provided source assembly.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="TestResult"/>.
        /// </returns>
        TestResult RunTests(TestRunRequest request);
    }
}
