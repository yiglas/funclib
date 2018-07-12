using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a new <see cref="Collections.HashSet"/> with the supplied keys. Any 
    /// equal keys are handled as if by repeated uses of <see cref="Conj"/>.
    /// </summary>
    public class HashSet :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Returns a new <see cref="Collections.HashSet"/> with the supplied keys. Any 
        /// equal keys are handled as if by repeated uses of <see cref="Conj"/>.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.HashSet.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.HashSet.EMPTY;
        /// <summary>
        /// Returns a new <see cref="Collections.HashSet"/> with the supplied keys. Any 
        /// equal keys are handled as if by repeated uses of <see cref="Conj"/>.
        /// </summary>
        /// <param name="keys">Keys to add to <see cref="Collections.HashSet"/> data structure.</param>
        /// <returns>
        /// Returns a new <see cref="Collections.HashSet"/> with the supplied keys.
        /// </returns>
        public object Invoke(params object[] keys) => Collections.HashSet.Create(keys);
    }
}
