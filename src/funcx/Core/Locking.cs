using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Locking : 
        IFunction<object>
    {
        object _locker;
        IFunction<object> _func;

        public Locking(object x, Func<object> fn)
        {
            this._locker = x;
            this._func = new Function<object>(fn);
        }
           
        public object Invoke()
        {
            lock (this._locker)
                return this._func.Invoke();
        }
    }
}
