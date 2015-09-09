using System;

namespace CodeRank.Api.Entities
{
    /// <summary>
    /// Flag to identify the comiler type
    /// </summary>
    [Serializable]
    public enum CompilerType
    {
        /// <summary>
        /// Flag indicating a undefined compiler types
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Flag indicating CSharp compiler
        /// </summary>
        CSharp = 1,

        /// <summary>
        /// Flag indicating Visual basic compiler
        /// </summary>
        VisualBasic = 2,

        /// <summary>
        /// Flag indicating Java compiler
        /// </summary>
        Java = 3,

        /// <summary>
        /// Flag indicating JavaScript compiler
        /// </summary>
        JavaScript = 4
    }
}
