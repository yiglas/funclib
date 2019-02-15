using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of x, f.Invoke(x), f.Invoke(f.Invoke(x))...
    /// f must be free of side-effects.
    /// </summary>
    public class Iterate :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of x, f.Invoke(x), f.Invoke(f.Invoke(x))...
        /// f must be free of side-effects.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="x">First object of sequence.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of x, f.Invoke(x), f.Invoke(f.Invoke(x))...
        /// f must be free of side-effects.
        /// </returns>
        public object Invoke(object f, object x) => Collections.Iterate.Create(f, x);
    }
}
