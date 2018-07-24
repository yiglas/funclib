using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the same as <see cref="Collections.List"/>'s <see cref="Collections.List.First"/> method, 
    /// for <see cref="Collections.Queue"/>'s <see cref="Collections.Queue.Peek"/> method, for 
    /// <see cref="Collections.Vector"/>'s <see cref="Last"/> (but much more efficient). If the collection
    /// is empty return null.
    /// </summary>
    public class Peek :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the same as <see cref="Collections.List"/>'s <see cref="Collections.List.First"/> method, 
        /// for <see cref="Collections.Queue"/>'s <see cref="Collections.Queue.Peek"/> method, for 
        /// <see cref="Collections.Vector"/>'s <see cref="Last"/> (but much more efficient). If the collection
        /// is empty return null.
        /// </summary>
        /// <param name="coll">An object that implements the <see cref="IStack"/> interface.</param>
        /// <returns>
        /// Returns the same as <see cref="Collections.List"/>'s <see cref="Collections.List.First"/> method, 
        /// for <see cref="Collections.Queue"/>'s <see cref="Collections.Queue.Peek"/> method, for 
        /// <see cref="Collections.Vector"/>'s <see cref="Last"/> (but much more efficient). If the collection
        /// is empty return null.
        /// </returns>
        public object Invoke(object coll) => coll is null ? null : ((IStack)coll).Peek();
    }
}
