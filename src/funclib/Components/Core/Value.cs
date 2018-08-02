using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the value in the <see cref="KeyValuePair"/> object.
    /// </summary>
    public class Value :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the value in the <see cref="KeyValuePair"/> object.
        /// </summary>
        /// <param name="e">A <see cref="KeyValuePair"/> object pulling the value from.</param>
        /// <returns>
        /// Returns the value in the <see cref="KeyValuePair"/> object.
        /// </returns>
        public object Invoke(object e) => ((KeyValuePair)e).Value;
    }
}
