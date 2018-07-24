using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a 
    /// <see cref="int"/>, 
    /// <see cref="long"/>, 
    /// <see cref="short"/> 
    /// <see cref="uint"/>, 
    /// <see cref="ulong"/>, 
    /// <see cref="ushort"/> 
    /// <see cref="char"/> 
    /// <see cref="byte"/>, 
    /// or <see cref="sbyte"/>, 
    /// otherwise <see cref="false"/>.
    /// </summary>
    public class IsInteger :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a 
        /// <see cref="int"/>, 
        /// <see cref="long"/>, 
        /// <see cref="short"/> 
        /// <see cref="uint"/>, 
        /// <see cref="ulong"/>, 
        /// <see cref="ushort"/> 
        /// <see cref="char"/> 
        /// <see cref="byte"/>, 
        /// or <see cref="sbyte"/>, 
        /// otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="n">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a 
        /// <see cref="int"/>, 
        /// <see cref="long"/>, 
        /// <see cref="short"/> 
        /// <see cref="uint"/>, 
        /// <see cref="ulong"/>, 
        /// <see cref="ushort"/> 
        /// <see cref="char"/> 
        /// <see cref="byte"/>, 
        /// or <see cref="sbyte"/>, 
        /// otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object n) =>
            or(n is int, n is long, n is short, n is uint, n is ulong, n is ushort, n is char, n is byte, n is sbyte);
    }
}
