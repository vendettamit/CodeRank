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
    /// Provides the base methods implementation and other centeralize handlings for derived class.
    /// </summary>
    public abstract class CompilerBase : ICompiler
    {
        /// <summary>
        /// Compiles the provides source code as string
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Compilation results generated after the compilation
        /// </returns>
        public CompileResult Compile(CompileArgs request)
        {
            try
            {
                return this.InnerCompile(request);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
                throw;
            }
        }

        /// <summary>
        /// The handle exception.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        protected virtual void HandleException(Exception exception)
        {
            // Do some operation in the base class.
        }

        /// <summary>
        /// Inner compiles the provides source code as string. This method must be implemented by dervied class.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Assembly generated after the compilation
        /// </returns>
        protected abstract CompileResult InnerCompile(CompileArgs request);
    }
}
