using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Divides number(s).
    /// </summary>
    public class Divide :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Divides number(s).
        /// </summary>
        /// <param name="x">The numerator of the equation.</param>
        /// <returns>
        /// Returns either <see cref="double"/> or <see cref="long"/> depending on the input. With 1 as the denominator.
        /// </returns>
        public object Invoke(object x) => Invoke(1, x);
        /// <summary>
        /// Divides number(s).
        /// </summary>
        /// <param name="x">The denominator of the equation.</param>
        /// <param name="y">The numerator of the equation.</param>
        /// <returns>
        /// Returns either <see cref="double"/> or <see cref="long"/> depending on the input for the equation: x/y
        /// </returns>
        public object Invoke(object x, object y) => Numbers.Divide(x, y);
        /// <summary>
        /// Divides number(s).
        /// </summary>
        /// <param name="x">The denominator of the equation.</param>
        /// <param name="y">The numerator of the equation.</param>
        /// <param name="more">Rest of the numerators applied left-to-right.</param>
        /// <returns>
        /// Returns either <see cref="double"/> or <see cref="long"/> depending on the input for the equation: x/y/more...
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => funclib.Core.Reduce1(this, Invoke(x, y), more);
    }
}
