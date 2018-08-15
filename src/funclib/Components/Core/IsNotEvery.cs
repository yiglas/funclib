using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="false"/> if x is logical true for every item in coll, otherwise <see cref="true"/>.
    /// </summary>
    public class IsNotEvery :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns <see cref="false"/> if x is logical true for every item in coll, otherwise <see cref="true"/>.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection of items to test.</param>
        /// <returns>
        /// Returns <see cref="false"/> if x is logical true for every item in coll, otherwise <see cref="true"/>.
        /// </returns>
        public object Invoke(object pred, object coll) => funclib.Core.Invoke(funclib.Core.Comp(funclib.Core.not, funclib.Core.isEvery), pred, coll);
    }
}
