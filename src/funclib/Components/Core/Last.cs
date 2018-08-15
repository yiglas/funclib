using funclib.Components.Core.Generic;

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
            var n = funclib.Core.Next(s);
            if ((bool)funclib.Core.Truthy(n))
                return Invoke(n);

            return funclib.Core.First(s);
        }
            
    }
}
