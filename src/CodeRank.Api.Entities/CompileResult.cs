using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace CodeRank.Api.Entities
{
    /// <summary>
    /// Contains the specific type of result from the Unit test runner.
    /// </summary>
    [DataContract]
    [Serializable]
    public class CompileResult
    {
        /// <summary>
        /// Gets or sets the error location in the file row and columns respectively.
        /// </summary>
        [DataMember]
        public Tuple<int, int> ErrorLocation { get; set; }

        /// <summary>
        /// Gets or sets the line number location in the source code.
        /// </summary>
        [DataMember]
        public string FirstErrorLine { get; set; }

        /// <summary>
        /// Gets or sets the Generated assembly after compilation
        /// </summary>
        /// <remarks>
        /// The assembly should not be sent to the client. So do not mark it with the attribute [DataMember]
        /// </remarks>
        public Assembly GeneratedAssembly { get; set; }

        /// <summary>
        /// Gets or sets the assembly file name.
        /// </summary>
        public string AssemblyFileName { get; set; }

        /// <summary>
        /// Gets or sets the loaded stream of Assembly from Compiled code.
        /// </summary>
        public MemoryStream LoadedStream { get; set; }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        [DataMember]
        public string Error { get; set; }
    }
}
