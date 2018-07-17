using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Constructs an <see cref="Collections.ArrayMap"/>. If any keys are equal,
    /// they are handled as if by repeated uses of <see cref="Assoc"/>.
    /// </summary>
    public class ArrayMap :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Constructs an <see cref="Collections.ArrayMap"/>. If any keys are equal,
        /// they are handled as if by repeated uses of <see cref="Assoc"/>.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.ArrayMap.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.ArrayMap.EMPTY;
        /// <summary>
        /// Constructs an <see cref="Collections.ArrayMap"/>. If any keys are equal,
        /// they are handled as if by repeated uses of <see cref="Assoc"/>.
        /// </summary>
        /// <param name="keyvals">List of Key, Value pairs.</param>
        /// <returns>
        /// Returns a new <see cref="Collections.ArrayMap"/> with Key/Value pairs added.
        /// </returns>
        public object Invoke(params object[] keyvals) => Collections.ArrayMap.Create(keyvals);
    }
}
