using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
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

            return func((object x, object y) =>
            {
                object ret = 0;

                if ((bool)truthy(p.Invoke(x, y)))
                    ret = -1;
                else if ((bool)truthy(p.Invoke(y, x)))
                    ret = 1;

                return ret;
            });
        }
    }
}
