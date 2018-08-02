using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Atomically sets the value of the <see cref="IAtom"/>
    /// to the new value if and only if the current value of 
    /// the <see cref="IAtom"/> is identical to the oldVal.
    /// Returns <see cref="true"/> if set happened, otherwise <see cref="false"/>.
    /// </summary>
    public class CompareAndSetǃ :
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Atomically sets the value of the <see cref="IAtom"/>
        /// to the new value if and only if the current value of 
        /// the <see cref="IAtom"/> is identical to the oldVal.
        /// Returns <see cref="true"/> if set happened, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="atom">An object that implements the <see cref="IAtom"/> interface.</param>
        /// <param name="oldVal">Current state of the atom.</param>
        /// <param name="newVal">New state of the atom after successful swap.</param>
        /// <returns>
        /// Returns <see cref="true"/> if set happened, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object atom, object oldVal, object newVal) => ((IAtom)atom).CompareAndSet(oldVal, newVal);
    }
}
