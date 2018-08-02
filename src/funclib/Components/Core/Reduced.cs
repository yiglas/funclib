using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Wraps x in a way such that a <see cref="Reduce"/> will terminate with the value x.
    /// </summary>
    public class Reduced :
        IDeref,
        IFunction<object, object>
    {
        readonly object _val;

        Reduced(object val) => this._val = val;

        /// <summary>
        /// Creates a new <see cref="Reduced"/> object.
        /// </summary>
        public Reduced()
        {
        }

        /// <summary>
        /// Returns the current state of ref.
        /// </summary>
        /// <returns>
        /// Returns the current state of ref.
        /// </returns>
        public object Deref() => this._val;

        /// <summary>
        /// Wraps x in a way such that a <see cref="Reduce"/> will terminate with the value x.
        /// </summary>
        /// <param name="x">Object to wrap.</param>
        /// <returns>
        /// Returns <see cref="Reduced"/> object that wraps x.
        /// </returns>
        public object Invoke(object x) => new Reduced(x);
    }
}
