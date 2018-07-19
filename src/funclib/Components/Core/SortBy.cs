using System;
using System.Collections.Generic;
using System.Text;

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
        public object Invoke(object keyfn, object coll) => Invoke(keyfn, new Compare(), coll);
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
        public object Invoke(object keyfn, object comp, object coll)
        {
            var fn = (IFunction<object, object>)keyfn;
            var cfn = (IFunction<object, object, object>)comp;

            return new Sort().Invoke(new Function<object, object, object>((x, y) => cfn.Invoke(fn.Invoke(x), fn.Invoke(y))), coll);
        }
    }
}
