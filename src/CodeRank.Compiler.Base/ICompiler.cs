using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Api.Entities;

namespace CodeRank.Compiler.Base
{
    /// <summary>
    /// Provides the methods require to implement a supported compiler for give source code.
    /// </summary>
    public interface ICompiler
    {
        /// <summary>
        /// Compiles the provides source code as string
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Assembly generated after the compilation
        /// </returns>
        CompileResult Compile(CompileArgs request);
    }
}
