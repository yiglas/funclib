using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a <see cref="IFunction{T1, T2, TResult}"/> function that can be coerced into 
    /// the <see cref="FunctionComparer"/> that implements <see cref="System.Collections.IComparer"/> 
    /// interface.
    /// </summary>
    public class Comparator :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="IFunction{T1, T2, TResult}"/> function that can be coerced into 
        /// the <see cref="FunctionComparer"/> that implements <see cref="System.Collections.IComparer"/> 
        /// interface.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="int"/> that will be: -1 if pred.Invoke(x, y) is truthy, or 1 if pred.Invoke(y, x) is truthy, otherwise 0
        /// </returns>
        public object Invoke(object pred)
        {
            var p = (IFunction<object, object, object>)pred;

            return new Function<object, object, object>((x, y) =>
            {
                if ((bool)new Truthy().Invoke(p.Invoke(x, y)))
                    return -1;
                else if ((bool)new Truthy().Invoke(p.Invoke(y, x)))
                    return 1;
                else
                    return 0;
            });
        }
    }
}
