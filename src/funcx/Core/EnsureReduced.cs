using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// If x is already <see cref="IsReduced"/>, return it else return <see cref="Collections.Reduced.Deref"/> value.
    /// </summary>
    public class EnsureReduced :
        IFunction<object, object>
    {
        /// <summary>
        /// If x is already <see cref="IsReduced"/>, return it else return <see cref="Collections.Reduced.Deref"/> value.
        /// </summary>
        /// <param name="x">Object to reduce or not.</param>
        /// <returns>
        /// Either x if it already <see cref="IsReduced"/> or <see cref="Collections.Reduced.Deref"/>ed value.
        /// </returns>
        public object Invoke(object x) => x is Collections.Reduced r ? r.Deref() : x;
    }
}
