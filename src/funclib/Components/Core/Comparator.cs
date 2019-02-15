using funclib.Components.Core.Generic;

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
        /// Returns a <see cref="IFunction{T1, T2, TResult}"/> that when invoked should return : -1 if pred.Invoke(x, y) is truthy, or 1 if pred.Invoke(y, x) is truthy, otherwise 0
        /// </returns>
        public object Invoke(object pred) =>
            funclib.Core.Func((x, y) =>
            {
                object ret = 0;

                if (funclib.Core.T(funclib.Core.Invoke(pred, x, y)))
                    ret = -1;
                else if (funclib.Core.T(funclib.Core.Invoke(pred, y, x)))
                    ret = 1;

                return ret;
            });
    }
}
