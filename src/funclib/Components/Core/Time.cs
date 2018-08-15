using funclib.Components.Core.Generic;
using System;
using System.Diagnostics;

namespace funclib.Components.Core
{
    /// <summary>
    /// Evaluates the <see cref="IFunction{TResult}"/> and prints the time it took. 
    /// Returns the value of <see cref="IFunction{TResult}"/>.
    /// </summary>
    public class Time :
        IMacroFunction
    {
        IFunction<object> _func;

        /// <summary>
        /// Evaluates the <see cref="IFunction{TResult}"/> and prints the time it took. 
        /// Returns the value of <see cref="IFunction{TResult}"/>.
        /// </summary>
        /// <param name="fn">Take a <see cref="Func{TResult}"/> and convert it to <see cref="IFunction{TResult}"/> to be executed.</param>
        public Time(Func<object> fn) : this(funclib.Core.Func(fn)) { }
        /// <summary>
        /// Evaluates the <see cref="IFunction{TResult}"/> and prints the time it took. 
        /// Returns the value of <see cref="IFunction{TResult}"/>.
        /// </summary>
        /// <param name="fn">A function to be executed.</param>
        public Time(IFunction<object> fn)
        {
            this._func = fn;
        }

        /// <summary>
        /// Evaluates the <see cref="IFunction{TResult}"/> and prints the time it took. 
        /// Returns the value of <see cref="IFunction{TResult}"/>.
        /// </summary>
        /// <returns>
        /// Returns the value of <see cref="IFunction{TResult}"/>.
        /// </returns>
        public object Invoke()
        {
            var sw = Stopwatch.StartNew();
            var ret = this._func.Invoke();
            sw.Stop();
            funclib.Core.PrintLn($"Elapsed time: {sw.Elapsed}");
            return ret;
        }
    }
}
