using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    ///  Removes a watch from the <see cref="ARef"/>'s reference.
    /// </summary>
    public class RemoveWatch :
        IFunction<object, object, object>
    {
        /// <summary>
        ///  Removes a watch from the <see cref="ARef"/>'s reference.
        /// </summary>
        /// <param name="ref">An object that implements the <see cref="IRef"/> interface.</param>
        /// <param name="key">A unique key for the function to be removed.</param>
        /// <returns>
        /// Returns this <see cref="ARef"/> object.
        /// </returns>
        public object Invoke(object @ref, object key) => ((IRef)@ref).RemoveWatch(key);
    }
}
