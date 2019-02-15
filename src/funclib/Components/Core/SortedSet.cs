using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a new <see cref="Collections.SortedSet"/> with the supplied keys. Any
    /// equal keys are handled as if by repeated uses of <see cref="funclib.Components.Core.Conj"/>.
    /// </summary>
    public class SortedSet :
        IFunction<object>,
        IFunctionParams<object, object>
    {
        /// <summary>
        /// Returns a new <see cref="Collections.SortedSet"/> with the supplied keys. Any
        /// equal keys are handled as if by repeated uses of <see cref="funclib.Components.Core.Conj"/>.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.SortedSet.EMPTY"/>.
        /// </returns>
        public object Invoke() => Collections.SortedSet.EMPTY;
        /// <summary>
        /// Returns a new <see cref="Collections.SortedSet"/> with the supplied keys. Any
        /// equal keys are handled as if by repeated uses of <see cref="funclib.Components.Core.Conj"/>.
        /// </summary>
        /// <param name="keys">Keys to add to <see cref="Collections.SortedSet"/> data structure.</param>
        /// <returns>
        /// Returns a new <see cref="Collections.SortedSet"/> with the supplied keys. Any
        /// equal keys are handled as if by repeated uses of <see cref="funclib.Components.Core.Conj"/>.
        /// </returns>
        public object Invoke(params object[] keys) => Collections.SortedSet.Create(keys);
    }
}
