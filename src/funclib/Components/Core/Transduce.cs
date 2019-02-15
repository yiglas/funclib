using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// This is still experimental!
    /// Reduce with a transformation of f (xf). If init is not supplied <see cref="IFunction{TResult}"/> is
    /// called to produce it. f should be a reducing step function that accepts both 1 and 2 arguments, if
    /// it accepts only 2 you can add the arity-1 with <see cref="funclib.Components.Core.Completing"/>. Returns the result of
    /// applying (thetransformed) xf to init and the funclib.Core.First( item in coll, then applying xf to the result
    /// of the 2nd item, etc. If coll contains no items, returns init and f is not called. Note: that
    /// certain transforms my inject or skip items.
    /// </summary>
    public class Transduce :
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>
    {
        /// <summary>
        /// This is still experimental!
        /// Reduce with a transformation of f (xf). If init is not supplied <see cref="IFunction{TResult}"/> is
        /// called to produce it. f should be a reducing step function that accepts both 1 and 2 arguments, if
        /// it accepts only 2 you can add the arity-1 with <see cref="funclib.Components.Core.Completing"/>. Returns the result of
        /// applying (thetransformed) xf to init and the funclib.Core.First( item in coll, then applying xf to the result
        /// of the 2nd item, etc. If coll contains no items, returns init and f is not called. Note: that
        /// certain transforms my inject or skip items.
        /// </summary>
        /// <param name="xform">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="coll">A collection of items to reduce.</param>
        /// <returns>
        /// Returns the result of applying (thetransformed) xf to init and the funclib.Core.First( item in coll, then applying
        /// xf to the result of the 2nd item, etc. If coll contains no items, returns init and f is not called.
        /// </returns>
        public object Invoke(object xform, object f, object coll) => Invoke(xform, f, funclib.Core.Invoke(f), coll);
        /// <summary>
        /// This is still experimental!
        /// Reduce with a transformation of f (xf). If init is not supplied <see cref="IFunction{TResult}"/> is
        /// called to produce it. f should be a reducing step function that accepts both 1 and 2 arguments, if
        /// it accepts only 2 you can add the arity-1 with <see cref="funclib.Components.Core.Completing"/>. Returns the result of
        /// applying (thetransformed) xf to init and the funclib.Core.First( item in coll, then applying xf to the result
        /// of the 2nd item, etc. If coll contains no items, returns init and f is not called. Note: that
        /// certain transforms my inject or skip items.
        /// </summary>
        /// <param name="xform">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="init">The initial seed value.</param>
        /// <param name="coll">A collection of items to reduce.</param>
        /// <returns>
        /// Returns the result of applying (thetransformed) xf to init and the funclib.Core.First( item in coll, then applying
        /// xf to the result of the 2nd item, etc. If coll contains no items, returns init and f is not called.
        /// </returns>
        public object Invoke(object xform, object f, object init, object coll)
        {
            var xf = funclib.Core.Invoke(xform, f);
            object ret;

            if (coll is IReduce r)
                ret = r.Reduce(xf, init);
            else
                ret = funclib.Core.Reduce(xf, init);

            return funclib.Core.Invoke(xf, ret);
        }
    }
}
