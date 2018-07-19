using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the first logical <see cref="true"/> value of execute <see cref="IFunction{T1, TResult}"/> pred passing
    /// x, where x is any x in coll, otherwise null.
    /// </summary>
    public class Some :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the first logical <see cref="true"/> value of execute <see cref="IFunction{T1, TResult}"/> pred passing
        /// x, where x is any x in coll, otherwise null.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection to be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns the first logical <see cref="true"/> value of execute <see cref="IFunction{T1, TResult}"/> pred passing
        /// x, where x is any x in coll, otherwise null.
        /// </returns>
        public object Invoke(object pred, object coll)
        {
            var fn = (IFunction<object, object>)pred;
            var s = (ISeq)new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(s))
            {
                return new Or().Invoke(
                    fn.Invoke(s.First()),
                    Invoke(pred, s.Next())
                    );
            }
            return null;
        }
    }
}
