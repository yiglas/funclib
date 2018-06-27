using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a <see cref="IFunctionParams{TRest, TResult}"/> that takes any number of 
    /// arguments and returns x.
    /// </summary>
    public class Constantly :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="IFunctionParams{TRest, TResult}"/> that takes any number of 
        /// arguments and returns x.
        /// </summary>
        /// <param name="x">Object to return.</param>
        /// <returns>
        /// Returns a <see cref="IFunctionParams{TRest, TResult}"/> when invoked returns x.
        /// </returns>
        public object Invoke(object x) => new FunctionParams<object, object>(args => x);
    }
}
