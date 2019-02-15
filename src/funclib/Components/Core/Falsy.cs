using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if the object is a logical false. i.e. 
    /// If source is null or source is bool and that value is false.
    /// </summary>
    public class Falsy :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns true if the object is a logical false. i.e. 
        /// If source is null or source is bool and that value is false.
        /// </summary>
        /// <param name="source">Object to test.</param>
        /// <returns>
        /// Returns true if the object is a logical false. i.e. 
        /// If source is null or source is bool and that value is false.
        /// </returns>
        public object Invoke(object source)
        {
            if (source is null) 
                return true;

            if (source is bool b) 
                return !b;

            return false;
        }
    }
}
