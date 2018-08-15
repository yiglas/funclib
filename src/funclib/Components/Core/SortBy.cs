using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a sorted sequence of the items in coll, where the sort
    /// order is determined by comparing <see cref="IFunction{T1, TResult}"/> key function.
    /// If no comparator is suppled, uses <see cref="Compare"/>.
    /// </summary>
    public class SortBy :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a sorted sequence of the items in coll, where the sort
        /// order is determined by comparing <see cref="IFunction{T1, TResult}"/> key function.
        /// If no comparator is suppled, uses <see cref="Compare"/>.
        /// </summary>
        /// <param name="keyfn">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection to sort.</param>
        /// <returns>
        /// Returns a sorted sequence of the items in coll, where the sort
        /// order is determined by comparing <see cref="IFunction{T1, TResult}"/> key function.
        /// If no comparator is suppled, uses <see cref="Compare"/>.
        /// </returns>
        public object Invoke(object keyfn, object coll) => Invoke(keyfn, funclib.Core.compare, coll);
        /// <summary>
        /// Returns a sorted sequence of the items in coll, where the sort
        /// order is determined by comparing <see cref="IFunction{T1, TResult}"/> key function.
        /// If no comparator is suppled, uses <see cref="Compare"/>.
        /// </summary>
        /// <param name="keyfn">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="comp">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">A collection to sort.</param>
        /// <returns>
        /// Returns a sorted sequence of the items in coll, where the sort
        /// order is determined by comparing <see cref="IFunction{T1, TResult}"/> key function.
        /// If no comparator is suppled, uses <see cref="Compare"/>.
        /// </returns>
        public object Invoke(object keyfn, object comp, object coll) =>
            funclib.Core.Sort(funclib.Core.Func((object x, object y) => funclib.Core.Invoke(comp, funclib.Core.Invoke(keyfn, x), funclib.Core.Invoke(keyfn, y))), coll);
    }
}
