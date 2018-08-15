using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the funclib.Core.First( logical <see cref="true"/> value of execute <see cref="IFunction{T1, TResult}"/> pred passing
    /// x, where x is any x in coll, otherwise null.
    /// </summary>
    public class Some :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the funclib.Core.First( logical <see cref="true"/> value of execute <see cref="IFunction{T1, TResult}"/> pred passing
        /// x, where x is any x in coll, otherwise null.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection to be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns the funclib.Core.First( logical <see cref="true"/> value of execute <see cref="IFunction{T1, TResult}"/> pred passing
        /// x, where x is any x in coll, otherwise null.
        /// </returns>
        public object Invoke(object pred, object coll)
        {
            var s = funclib.Core.Seq(coll);
            if ((bool)funclib.Core.Truthy(s))
            {
                return funclib.Core.Or(funclib.Core.Invoke(pred, funclib.Core.First(s)), Invoke(pred, funclib.Core.Next(s)));
            }
            return null;
        }
    }
}
