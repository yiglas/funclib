using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Repeatedly execute body (presumably for side-effects).
    /// </summary>
    public class DoTimes :
        IMacroFunction
    {
        readonly int _n;
        readonly IFunction<object, object> _func;

        /// <summary>
        /// Constructor for the <see cref="DoTimes"/> class.
        /// </summary>
        /// <param name="n">Number of times to execute the fn.</param>
        /// <param name="fn">The function to execute.</param>
        public DoTimes(int n, Func<object, object> fn) :
            this(n, funclib.Core.Func(fn))
        {
        }

        /// <summary>
        /// Constructor for the <see cref="DoTimes"/> class.
        /// </summary>
        /// <param name="n">Number of times to execute the fn.</param>
        /// <param name="fn">The function to execute.</param>
        public DoTimes(int n, IFunction<object, object> fn)
        {
            this._func = fn;
            this._n = Numbers.ConvertToInt(n);
        }

        /// <summary>
        /// Executes the function x time.
        /// </summary>
        /// <returns>Returns null.</returns>
        public object Invoke()
        {
            for (int i = 0; i < this._n; i++)
                this._func.Invoke(i);

            return null;
        }
    }
}
