using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Atomically swaps the value of atom to be: funclib.Core.Invoke(f, current-value-of-atom, ...args).
    /// Note: f may be called multiple times and thus should be free of side effects.
    /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
    /// the swap.
    /// </summary>
    public class Swapǃ :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>
    {
        /// <summary>
        /// Atomically swaps the value of atom to be: funclib.Core.Invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="atom">An object that implements the <see cref="IAtom"/> interface.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        public object Invoke(object atom, object f) => ((IAtom)atom).Swap(f);
        /// <summary>
        /// Atomically swaps the value of atom to be: funclib.Core.Invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="atom">An object that implements the <see cref="IAtom"/> interface.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        public object Invoke(object atom, object f, object x) => ((IAtom)atom).Swap(f, x);
        /// <summary>
        /// Atomically swaps the value of atom to be: funclib.Core.Invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="atom">An object that implements the <see cref="IAtom"/> interface.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <param name="y">Third parameter of the function.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        public object Invoke(object atom, object f, object x, object y) => ((IAtom)atom).Swap(f, x, y);
        /// <summary>
        /// Atomically swaps the value of atom to be: funclib.Core.Invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="atom">An object that implements the <see cref="IAtom"/> interface.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <param name="y">Third parameter of the function.</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Invoke(object atom, object f, object x, object y, params object[] args) => ((IAtom)atom).Swap(f, x, y, args);
    }
}
