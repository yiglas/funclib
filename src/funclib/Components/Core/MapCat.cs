using funclib.Components.Core.Generic;

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
        public object Invoke(object f) => funclib.Core.Comp(funclib.Core.Map(f), funclib.Core.cat);
        /// <summary>
        /// Returns the result of applying <see cref="Concat"/> to the result of applying 
        /// <see cref="Map"/> to f and colls. Thus function f should return a collections.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
        /// <param name="colls">A collection of items.</param>
        /// <returns>
        /// Returns a collection.
        /// </returns>
        public object Invoke(object f, params object[] colls) => funclib.Core.Apply(funclib.Core.concat, funclib.Core.Apply(funclib.Core.map, f, colls));
    }
}
