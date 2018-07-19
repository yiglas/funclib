using System;
using System.Collections.Generic;
using System.Text;

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
            new Or().Invoke(
                n is Int32,
                n is Int64,
                n is Int16,
                n is UInt32,
                n is UInt64,
                n is UInt16,
                n is Char,
                n is Byte,
                n is SByte);
    }
}
