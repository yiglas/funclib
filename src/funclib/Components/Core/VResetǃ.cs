using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Sets the value of <see cref="Volatile"/> to a new value without 
    /// regard for the current value
    /// </summary>
    public class VResetǃ :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Sets the value of <see cref="Volatile"/> to a newValue without 
        /// regard for the current value
        /// </summary>
        /// <param name="vol">A <see cref="Volatile"/> object</param>
        /// <param name="newVal">The new value for the <see cref="Volatile"/> object.</param>
        /// <returns>
        /// Returns the new <see cref="Volatile"/> object set to newVal.
        /// </returns>
        public object Invoke(object vol, object newVal) => ((Volatileǃ)vol).Reset(newVal);
    }
}
