using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Sets the value of <see cref="IAtom"/> to the new value without regard for
    /// the current value. Returns newVal;
    /// </summary>
    public class Resetǃ :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Sets the value of <see cref="IAtom"/> to the new value without regard for
        /// the current value. Returns newVal;
        /// </summary>
        /// <param name="atom">An object that implements the <see cref="IAtom"/> interface.</param>
        /// <param name="newVal">The new values for the <see cref="IAtom"/>.</param>
        /// <returns>
        /// Returns the newVal object.
        /// </returns>
        public object Invoke(object atom, object newVal) => ((IAtom)atom).Reset(newVal);
    }
}
