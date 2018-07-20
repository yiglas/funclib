using System;
using System.Linq;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Evaluates the expressions in order and returns the value of the last. 
    /// If no expressions are supplied, returns null.
    /// </summary>
    public class Do :
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Evaluates the expressions in order and returns the value of the last. 
        /// If no expressions are supplied, returns null.
        /// </summary>
        /// <param name="rest">Objects array.</param>
        /// <returns>
        /// Returns the value of the last.
        /// </returns>
        public object Invoke(params object[] rest) => rest?.LastOrDefault();
    }
}
