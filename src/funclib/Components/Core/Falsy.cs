using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if the object is a logical false. i.e. 
    /// If source is null or source is bool and that value is false.
    /// </summary>
    public class Falsy :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if the object is a logical false. i.e. 
        /// If source is null or source is bool and that value is false.
        /// </summary>
        /// <param name="source">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if the object is a logical false. i.e. 
        /// If source is null or source is bool and that value is false.
        /// </returns>
        public object Invoke(object source)
        {
            if (source is null) return true;
            else if (source is bool b) return !b;
            else return false;
        }
    }
}
