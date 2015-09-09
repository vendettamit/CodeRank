using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Framework.Validations
{
    /// <summary>
    /// Extensions for invoking validations on any control.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Validates any object and throws an exception if the object is null.
        /// </summary>
        /// <param name="this">
        /// The object that will be verified.
        /// </param>
        /// <param name="customMessage">
        /// Custom error message that Exception will be containing.
        /// </param>
        /// <exception cref="ArgumentNullException">The value of source object was null.
        /// </exception>
        public static void MustNotBeNull(this object @this, string customMessage = "")
        {
            string defaultErrorMessage = string.Format("Object of {0} must not be null.", @this.GetType());

            if (@this == null)
            {
                throw new ArgumentNullException(!string.IsNullOrWhiteSpace(customMessage) ? customMessage : defaultErrorMessage);
            }
        }
    }
}
