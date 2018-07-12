using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a <see cref="HashMap"/> of elements of coll keyed by the result of 
    /// <see cref="IFunction{T1, TResult}"/> f. The value at each key will be a 
    /// <see cref="Vector"/> of the corresponding elements, in the order they appeared 
    /// in coll.
    /// </summary>
    public class GroupBy :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="HashMap"/> of elements of coll keyed by the result of 
        /// <see cref="IFunction{T1, TResult}"/> f. The value at each key will be a 
        /// <see cref="Vector"/> of the corresponding elements, in the order they appeared 
        /// in coll.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection of items to group by.</param>
        /// <returns>
        /// Returns a <see cref="HashMap"/> of elements of coll keyed by the result of 
        /// <see cref="IFunction{T1, TResult}"/> f.
        /// </returns>
        public object Invoke(object f, object coll) =>
            new Persistentǃ().Invoke(
                new Reduce().Invoke(
                    new Function<object, object, object>((ret, x) =>
                    {
                        var k = ((IFunction<object, object>)f).Invoke(x);
                        return new Assocǃ().Invoke(ret, k, new Conj().Invoke(new Get().Invoke(ret, k, new Vector().Invoke()), x));
                    }), new Transient().Invoke(new HashMap().Invoke()), coll));
    }

}
