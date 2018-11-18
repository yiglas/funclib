using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns false if x is logical true for any item in coll, otherwise true.
    /// </summary>
    public class IsNotAny :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns true if x is logical true for any item in coll, otherwise false.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection of items to test.</param>
        /// <returns>
        /// Returns true if x is logical true for any item in coll, otherwise false.
        /// </returns>
        public object Invoke(object pred, object coll) => funclib.Core.Invoke(funclib.Core.Comp(funclib.Core.not, funclib.Core.some), pred, coll);
    }
}
