using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.HashMap"/> of elements of coll keyed by the result of
    /// <see cref="IFunction{T1, TResult}"/> f. The value at each key will be a
    /// <see cref="funclib.Components.Core.Vector"/> of the corresponding elements, in the order they appeared
    /// in coll.
    /// </summary>
    public class GroupBy :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.HashMap"/> of elements of coll keyed by the result of
        /// <see cref="IFunction{T1, TResult}"/> f. The value at each key will be a
        /// <see cref="funclib.Components.Core.Vector"/> of the corresponding elements, in the order they appeared
        /// in coll.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection of items to group by.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.HashMap"/> of elements of coll keyed by the result of
        /// <see cref="IFunction{T1, TResult}"/> f.
        /// </returns>
        public object Invoke(object f, object coll) =>
            funclib.Core.Persistentǃ(
                funclib.Core.Reduce(
                    funclib.Core.Func((ret, x) =>
                    {
                        var k = funclib.Core.Invoke(f, x);
                        return funclib.Core.Assocǃ(
                            ret,
                            k,
                            funclib.Core.Conj(
                                funclib.Core.Get(
                                    ret,
                                    k,
                                    funclib.Core.Vector()),
                                x));
                    }), funclib.Core.Transient(funclib.Core.HashMap()), coll));
    }

}
