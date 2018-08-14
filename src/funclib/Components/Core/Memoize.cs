using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a memoized version of the referentially transparent function. The 
    /// memoized version of the function keeps a cache of the mapping from arguments
    /// to results and, when calls with the same arguments are repeated often, has
    /// higher performance at the expense of higher memory use.
    /// </summary>
    public class Memoize :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a memoized version of the referentially transparent function. The 
        /// memoized version of the function keeps a cache of the mapping from arguments
        /// to results and, when calls with the same arguments are repeated often, has
        /// higher performance at the expense of higher memory use.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="Function"/> object that is a memoized version of the function.
        /// </returns>
        public object Invoke(object f) => new Function(f);

        /// <summary>
        /// Internal function that does the <see cref="Memoize"/>.
        /// </summary>
        public class Function : 
            IFunctionParams<object, object>
        {
            object _f;
            object _mem;

            internal Function(object f)
            {
                this._f = f;
                this._mem = atom(arrayMap());
            }

            /// <summary>
            /// Invokes the function with the given argument.
            /// </summary>
            /// <param name="args">List of given arguments for the function given.</param>
            /// <returns>
            /// The result of calling the function with the given argument.
            /// </returns>
            public object Invoke(params object[] args)
            {
                var e = find(deref(this._mem), args);
                if ((bool)truthy(e))
                {
                    return value(e);
                }

                var ret = apply(this._f, args);
                swapǃ(this._mem, funclib.core.Assoc, args, ret);
                return ret;
            }
        }
    }
}
