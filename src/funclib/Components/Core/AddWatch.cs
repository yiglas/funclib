using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Adds a watch function to an <see cref="IRef"/> variable. The
    /// watch function must implement the <see cref="IFunction"/> interface
    /// and take 4 arguments. The key, the reference, its old-state and its new
    /// state. Whenever the <see cref="IRef"/>'s state changes all registered
    /// watches will be called. The functions will be synchronously called. Note:
    /// an <see cref="IAtom"/>'s state may have changed prior to calling the
    /// function so use th old/new state argument instead of de-refing the
    /// state again.
    /// </summary>
    public class AddWatch :
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Adds a watch function to an <see cref="IRef"/> variable. The
        /// watch function must implement the <see cref="IFunction"/> interface
        /// and take 4 arguments. The key, the reference, its old-state and its new
        /// state. Whenever the <see cref="IRef"/>'s state changes all registered
        /// watches will be called. The functions will be synchronously called. Note:
        /// an <see cref="IAtom"/>'s state may have changed prior to calling the
        /// function so use th old/new state argument instead of de-refing the
        /// state again.
        /// </summary>
        /// <param name="ref">An object that implements the <see cref="IRef"/> interface.</param>
        /// <param name="key">A unique key for the function.</param>
        /// <param name="fn">An object that implements the <see cref="IFunction"/> interface and takes 4 arguments.</param>
        /// <returns>
        /// Returns the <see cref="ARef"/> object.
        /// </returns>
        public object Invoke(object @ref, object key, object fn)
        {
            return ((IRef)@ref).AddWatch(key, (IFunction)fn);
        }
    }
}
