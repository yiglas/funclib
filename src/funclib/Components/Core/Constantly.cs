using funclib.Components.Core.Generic;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
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
        public object Invoke(object x) => func((object[] args) => x);
    }
}
