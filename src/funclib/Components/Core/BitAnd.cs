using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Unary ampersand operator returns the address of its operand. Binary ampersand operators are
    /// predefined for the integral types and <see cref="bool"/>.
    /// </summary>
    public class BitAnd :
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Unary ampersand operator returns the address of its operand. Binary ampersand operators are
        /// predefined for the integral types and <see cref="bool"/>.
        /// </summary>
        /// <param name="x">Left hand side of the operand.</param>
        /// <param name="y">Right hand side of the operand.</param>
        /// <returns>
        /// Returns the <see cref="int"/> value of the operations.
        /// </returns>
        public object Invoke(object x, object y) => Numbers.And(x, y);
        /// <summary>
        /// Unary ampersand operator returns the address of its operand. Binary ampersand operators are
        /// predefined for the integral types and <see cref="bool"/>.
        /// </summary>
        /// <param name="x">Left hand side of the operand.</param>
        /// <param name="y">Right hand side of the operand.</param>
        /// <param name="more">Rest of the </param>
        /// <returns>
        /// Returns the <see cref="int"/> value of the operations.
        /// </returns>
        public object Invoke(object x, object y, params object[] more) => funclib.Core.Reduce1(this, Invoke(x, y), more);
    }
}
