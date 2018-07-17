using System;
using System.Collections.Generic;
using System.Text;

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
            var n = new Next().Invoke(s);
            if ((bool)new Truthy().Invoke(n))
                return Invoke(n);

            return new First().Invoke(s);
        }
            
    }
}
