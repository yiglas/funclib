using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// If x is already <see cref="IsReduced"/>, return it else return <see cref="Reduced"/> value.
    /// </summary>
    public class EnsureReduced :
        IFunction<object, object>
    {
        /// <summary>
        /// If x is already <see cref="IsReduced"/>, return it else return <see cref="Reduced"/> value.
        /// </summary>
        /// <param name="x">Object to reduce or not.</param>
        /// <returns>
        /// If x is already <see cref="IsReduced"/>, return it else return <see cref="Reduced"/> value.
        /// </returns>
        public object Invoke(object x) => x is Reduced r ? x : funclib.Core.Reduced(x);
    }
}
