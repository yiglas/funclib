using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Sets the value of <see cref="Volatileǃ"/> to a new value without 
    /// regard for the current value
    /// </summary>
    public class VResetǃ :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Sets the value of <see cref="Volatileǃ"/> to a newValue without 
        /// regard for the current value
        /// </summary>
        /// <param name="vol">A <see cref="Volatileǃ"/> object</param>
        /// <param name="newVal">The new value for the <see cref="Volatileǃ"/> object.</param>
        /// <returns>
        /// Returns the new <see cref="Volatileǃ"/> object set to newVal.
        /// </returns>
        public object Invoke(object vol, object newVal) => ((Volatileǃ)vol).Reset(newVal);
    }
}
