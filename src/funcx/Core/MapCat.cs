using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns the result of applying <see cref="Concat"/> to the result of applying 
    /// <see cref="Map"/> to f and colls. Thus function f should return a collections.
    /// </summary>
    public class MapCat :
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        public object Invoke(object f) => new Comp().Invoke(new Map().Invoke(f), new Cat());
        /// <summary>
        /// Returns the result of applying <see cref="Concat"/> to the result of applying 
        /// <see cref="Map"/> to f and colls. Thus function f should return a collections.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="colls">A collection of items.</param>
        /// <returns>
        /// Returns a collection.
        /// </returns>
        public object Invoke(object f, params object[] colls) => new Apply().Invoke(new Concat(), new Apply().Invoke(new Map(), f, colls));
    }
}
