using System;
using System.Diagnostics;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Time :
        IFunction<object>
    {
        IFunction<object> _func;

        public Time(Func<object> fn) : this(new Function<object>(fn)) { }
        public Time(IFunction<object> fn)
        {
            this._func = fn;
        }

        public object Invoke()
        {
            var sw = Stopwatch.StartNew();
            var ret = this._func.Invoke();
            sw.Stop();
            new PrintLn().Invoke($"Elapsed time: {sw.Elapsed}");
            return ret;
        }
    }
}
