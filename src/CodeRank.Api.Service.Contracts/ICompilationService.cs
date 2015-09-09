using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Api.Service.Contracts.Requests;
using CodeRank.Api.Service.Contracts.Response;

namespace CodeRank.Api.Service.Contracts
{
    /// <summary>
    /// Provides the methods for implementation of Compiler service
    /// </summary>
    [ServiceContract]
    public interface ICompilationService
    {
        /// <summary>
        /// The compile operation to compile the requested code unit.
        /// </summary>
        /// <param name="compileRequest">
        /// The compile request.
        /// </param>
        /// <returns>
        /// The <see cref="CompileResponse"/>.
        /// </returns>
        [OperationContract]
        CompileResponse Compile(CompileRequest compileRequest);

        /// <summary>
        /// Compiles the code and runs the test against the submitted code.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="CompileAndRunResponse"/>.
        /// </returns>
        /// <exception cref="FaultException">Unhandled exception
        /// </exception>
        [OperationContract]
        CompileAndRunResponse CompileAndRunTests(CompileAndRunRequest request);
    }
}
