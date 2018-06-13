using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class DoTimes :
        IFunction<object>
    {
        readonly int _n;
        readonly IFunction<int, object> _func;

        public DoTimes(int n, Func<int, object> fn) :
            this(n, new Function<int, object>(fn))
        {
        }

        public DoTimes(int n, IFunction<int, object> fn)
        {
            this._func = fn;
            this._n = Numbers.ConvertToInt(n);
        }

        public object Invoke()
        {
            for (int i = 0; i < this._n; i++)
                this._func.Invoke(this._n);

            return null;
        }
    }
}
