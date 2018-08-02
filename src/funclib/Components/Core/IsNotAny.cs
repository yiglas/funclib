using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="false"/> if x is logical true for any item in coll, otherwise <see cref="true"/>.
    /// </summary>
    public class IsNotAny :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is logical true for any item in coll, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection of items to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is logical true for any item in coll, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object pred, object coll) => invoke(comp(funclib.core.Not, funclib.core.Some), pred, coll);
    }
}
