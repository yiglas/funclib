using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a sorted collection of the items in coll. If no comparator is 
    /// supplied, use <see cref="Compare"/>.
    /// </summary>
    public class Sort :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </summary>
        /// <param name="coll">A collection to be sorted.</param>
        /// <returns>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </returns>
        public object Invoke(object coll) => Invoke(funclib.Core.compare, coll);
        /// <summary>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </summary>
        /// <param name="comp">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">A collection to be sorted.</param>
        /// <returns>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </returns>
        public object Invoke(object comp, object coll)
        {
            if ((bool)funclib.Core.Truthy(funclib.Core.Seq(coll)))
            {
                var a = (object[])funclib.Core.ToArray(coll);
                Array.Sort(a, new FunctionComparer(comp));
                return funclib.Core.Seq(a);
            }
            return funclib.Core.List();
        }
            
    }
}
