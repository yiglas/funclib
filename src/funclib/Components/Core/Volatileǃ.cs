﻿using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Creates and returns a <see cref="Volatileǃ"/> with an initial value of val.
    /// </summary>
    public class Volatileǃ :
        IDeref,
        IFunction<object, object>
    {
        volatile object _val;

        Volatileǃ(object val) => this._val = val;

        /// <summary>
        /// Creates a new <see cref="Volatileǃ"/> object.
        /// </summary>
        public Volatileǃ()
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
        /// Resets the volatile object, and returns it.
        /// </summary>
        /// <param name="newVal">New value of the volatile object.</param>
        /// <returns>
        /// Returns the new volatile object.
        /// </returns>
        public object Reset(object newVal) => this._val = newVal;

        /// <summary>
        /// Creates and returns a <see cref="Volatileǃ"/> with an initial value of val.
        /// </summary>
        /// <param name="val">Initial value.</param>
        /// <returns>
        /// Returns the <see cref="Volatileǃ"/> set to val.
        /// </returns>
        public object Invoke(object val) => new Volatileǃ(val);
    }
}
