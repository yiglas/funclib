using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// If x is <see cref="IsReduced"/> returns true, return <see cref="Reduced.Deref"/>,
    /// otherwise return x.
    /// </summary>
    public class Unreduce :
        IFunction<object, object>
    {
        /// <summary>
        /// If x is <see cref="IsReduced"/> returns true, return <see cref="Reduced.Deref"/>,
        /// otherwise return x.
        /// </summary>
        /// <param name="x">Object that can be <see cref="Reduced"/> or is already reduced.</param>
        /// <returns>
        /// If x is <see cref="IsReduced"/> returns true, return <see cref="Reduced.Deref"/>,
        /// otherwise return x.
        /// </returns>
        public object Invoke(object x) => x is Reduced r ? r.Deref() : x;
    }
}
