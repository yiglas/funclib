using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the last item in coll, in linear time.
    /// </summary>
    public class Last :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the last item in coll, in linear time.
        /// </summary>
        /// <param name="s">Object to return the last time for.</param>
        /// <returns>
        /// Returns the last item in coll, in linear time.
        /// </returns>
        public object Invoke(object s)
        {
            var n = next(s);
            if ((bool)truthy(n))
                return Invoke(n);

            return first(s);
        }
            
    }
}
