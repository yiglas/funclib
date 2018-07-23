using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Ensures that one thread does not enter a <see cref="IFunction{TResult}"/> while another
    /// thread is already executing it.
    /// </summary>
    public class Locking : 
        IMacroFunction
    {
        object _locker;
        IFunction<object> _func;

        /// <summary>
        /// Creates a <see cref="Locking"/> object.
        /// </summary>
        /// <param name="x">Object to lock.</param>
        /// <param name="fn"><see cref="Func{TResult}"/> to execute.</param>
        public Locking(object x, Func<object> fn) :
            this(x, func(fn))
        { }

        /// <summary>
        /// Creates a <see cref="Locking"/> object.
        /// </summary>
        /// <param name="x">Object to lock.</param>
        /// <param name="fn"><see cref="IFunction{TResult}"/> to execute.</param>
        public Locking(object x, IFunction<object> fn)
        {
            this._locker = x;
            this._func = fn;
        }

        /// <summary>
        /// Invokes the <see cref="IFunction{TResult}"/> wrapped with a lock statement.
        /// </summary>
        /// <returns>
        /// Returns the result of calling <see cref="IFunction{TResult}"/> function.
        /// </returns>
        public object Invoke()
        {
            lock (this._locker)
                return this._func.Invoke();
        }
    }
}
