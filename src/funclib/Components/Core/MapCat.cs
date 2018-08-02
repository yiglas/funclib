using funclib.Components.Core.Generic;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the result of applying <see cref="Concat"/> to the result of applying 
    /// <see cref="Map"/> to f and colls. Thus function f should return a collections.
    /// </summary>
    public class MapCat :
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke(object f) => comp(map(f), funclib.core.Cat);
        /// <summary>
        /// Returns the result of applying <see cref="Concat"/> to the result of applying 
        /// <see cref="Map"/> to f and colls. Thus function f should return a collections.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="colls">A collection of items.</param>
        /// <returns>
        /// Returns a collection.
        /// </returns>
        public object Invoke(object f, params object[] colls) => apply(funclib.core.Concat, apply(funclib.core.Map, f, colls));
    }
}
