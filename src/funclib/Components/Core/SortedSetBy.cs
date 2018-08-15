using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Collections.SortedSet"/> with supplied keys, using the supplied 
    /// <see cref="IFunction{T1, T2, TResult}"/> comparator. If any keys are equal, they are handled as
    /// if by repeated uses of <see cref="Conj"/>.
    /// </summary>
    public class SortedSetBy :
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="Collections.SortedSet"/> with supplied keys, using the supplied 
        /// <see cref="IFunction{T1, T2, TResult}"/> comparator. If any keys are equal, they are handled as
        /// if by repeated uses of <see cref="Conj"/>.
        /// </summary>
        /// <param name="comparator">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="keys">Keys to add to <see cref="Collections.SortedSet"/> data structure.</param>
        /// <returns>
        /// Returns a <see cref="Collections.SortedSet"/> with supplied keys, using the supplied 
        /// <see cref="IFunction{T1, T2, TResult}"/> comparator. If any keys are equal, they are handled as
        /// if by repeated uses of <see cref="Conj"/>.
        /// </returns>
        public object Invoke(object comparator, params object[] keys) => Collections.SortedSet.Create(new FunctionComparer(comparator), keys);
    }
}
