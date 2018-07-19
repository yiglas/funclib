using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Collections.Vector"/> of [<see cref="TakeWhile.Invoke(object, object)"/>, <see cref="DropWhile.Invoke(object, object)"/>].
    /// </summary>
    public class SplitWith :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="Collections.Vector"/> of [<see cref="TakeWhile.Invoke(object, object)"/>, <see cref="DropWhile.Invoke(object, object)"/>].
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">A collection being split.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> of [<see cref="TakeWhile.Invoke(object, object)"/>, <see cref="DropWhile.Invoke(object, object)"/>].
        /// </returns>
        public object Invoke(object pred, object coll) =>
            new Vector().Invoke(new TakeWhile().Invoke(pred, coll), new DropWhile().Invoke(pred, coll));
    }
}
