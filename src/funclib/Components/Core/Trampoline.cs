using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// <see cref="funclib.Components.Core.Trampoline"/> can be used to convert algorithms requiring mutual
    /// recursion without stake consumption. Calls f with supplied args, if any. If
    /// f returns a fn, calls the fn with no arguments and continues to repeat, until
    /// the return value is not a fn. then returns the non-fn value. Note: that if you
    /// want to return a fn as a final value, you must wrap it in some data structure
    /// and unpack it after trampoline returns.
    /// </summary>
    public class Trampoline :
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// <see cref="funclib.Components.Core.Trampoline"/> can be used to convert algorithms requiring mutual
        /// recursion without stake consumption. Calls f with supplied args, if any. If
        /// f returns a fn, calls the fn with no arguments and continues to repeat, until
        /// the return value is not a fn. then returns the non-fn value. Note: that if you
        /// want to return a fn as a final value, you must wrap it in some data structure
        /// and unpack it after trampoline returns.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{TResult}"/> interface.</param>
        /// <returns>
        /// Returns the funclib.Core.First( non-fn value.
        /// </returns>
        public object Invoke(object f)
        {
            var ret = funclib.Core.Invoke(f);
            if ((bool)funclib.Core.IsFunction(ret))
                return Invoke(ret);

            return ret;
        }
        /// <summary>
        /// <see cref="funclib.Components.Core.Trampoline"/> can be used to convert algorithms requiring mutual
        /// recursion without stake consumption. Calls f with supplied args, if any. If
        /// f returns a fn, calls the fn with no arguments and continues to repeat, until
        /// the return value is not a fn. then returns the non-fn value. Note: that if you
        /// want to return a fn as a final value, you must wrap it in some data structure
        /// and unpack it after trampoline returns.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="args">A list of parameters</param>
        /// <returns>
        /// Returns the funclib.Core.First( non-fn value.
        /// </returns>
        public object Invoke(object f, params object[] args) => Invoke(funclib.Core.Func(() => funclib.Core.Apply(f, args)));
    }
}
