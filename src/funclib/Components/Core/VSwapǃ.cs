using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Non-atomically swaps the value of volatile.
    /// </summary>
    public class VSwapǃ :
        IMacroFunction
    {
        Volatileǃ _v;
        object _f;
        object[] _args;

        /// <summary>
        /// Non-atomically swaps the value of volatile.
        /// </summary>
        /// <param name="vol">A <see cref="Volatile"/> object.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="args">Any additional arguments passed to f</param>
        public VSwapǃ(object vol, object f, params object[] args)
        {
            this._v = (Volatileǃ)vol;
            this._f = f;
            this._args = args;
        }

        /// <summary>
        /// Non-atomically swaps the value of volatile.
        /// </summary>
        /// <returns>
        /// Returns the reseted <see cref="Volatile"/> object.
        /// </returns>
        public object Invoke() => this._v.Reset(apply(this._f, this._v.Deref(), this._args));
    }
}
