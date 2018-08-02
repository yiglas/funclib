using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Repeatedly execute body (presumably for side-effects).
    /// </summary>
    public class DoTimes :
        IMacroFunction
    {
        readonly int _n;
        readonly IFunction<int, object> _func;

        /// <summary>
        /// Constructor for the <see cref="DoTimes"/> class.
        /// </summary>
        /// <param name="n">Number of times to execute the fn.</param>
        /// <param name="fn">The function to execute.</param>
        public DoTimes(int n, Func<int, object> fn) :
            this(n, func(fn))
        {
        }

        /// <summary>
        /// Constructor for the <see cref="DoTimes"/> class.
        /// </summary>
        /// <param name="n">Number of times to execute the fn.</param>
        /// <param name="fn">The function to execute.</param>
        public DoTimes(int n, IFunction<int, object> fn)
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
