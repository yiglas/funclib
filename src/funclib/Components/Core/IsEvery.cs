using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if <see cref="IFunction{T1, TResult}"/> pred is a logical 
    /// true for every item in the coll, otherwise <see cref="false"/>
    /// </summary>
    public class IsEvery :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if <see cref="IFunction{T1, TResult}"/> pred is a logical 
        /// true for every item in the coll, otherwise <see cref="false"/>
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">The collection to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if <see cref="IFunction{T1, TResult}"/> pred is a logical 
        /// true for every item in the coll, otherwise <see cref="false"/>
        /// </returns>
        public object Invoke(object pred, object coll)
        {
            if ((bool)isNull(new Seq().Invoke(coll))) return true;
            var fn = (IFunction<object, object>)pred;
            if ((bool)new Truthy().Invoke(fn.Invoke(first(coll))))
                return Invoke(pred, next(coll));
            return false;
        }
    }
}
