using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a new, persistent version of the <see cref="ITransientCollection"/>, in 
    /// constant time. The <see cref="ITransientCollection"/> cannot be used after this
    /// call.
    /// </summary>
    public class Persistentǃ :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a new, persistent version of the <see cref="ITransientCollection"/>, in 
        /// constant time. The <see cref="ITransientCollection"/> cannot be used after this
        /// call.
        /// </summary>
        /// <param name="coll">An object that implements the <see cref="ITransientCollection"/> interface.</param>
        /// <returns>
        /// Returns a new, persistent version of the <see cref="ITransientCollection"/>, in 
        /// constant time.
        /// </returns>
        public object Invoke(object coll) => ((ITransientCollection)coll).ToPersistent();
    }
}
