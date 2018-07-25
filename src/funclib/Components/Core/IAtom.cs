using funclib.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// The interface for a <see cref="IAtom"/> variable.
    /// </summary>
    public interface IAtom
    {
        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        IVector Swap(object f);
        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        IVector Swap(object f, object x);
        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <param name="y">Third parameter of the function.</param>
        /// <returns>
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </returns>
        IVector Swap(object f, object x, object y);
        /// <summary>
        /// Atomically swaps the value of atom to be: invoke(f, current-value-of-atom, ...args).
        /// Note: f may be called multiple times and thus should be free of side effects.
        /// Returns a <see cref="IVector"/> of old, new. The value of the atom before and after 
        /// the swap.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">Second parameter of the function.</param>
        /// <param name="y">Third parameter of the function.</param>
        /// <param name="args"></param>
        /// <returns></returns>
        IVector Swap(object f, object x, object y, params object[] args);
        /// <summary>
        /// Atomically sets the value of the <see cref="IAtom"/>
        /// to the new value if and only if the current value of 
        /// the <see cref="IAtom"/> is identical to the oldVal.
        /// Returns <see cref="true"/> if set happened, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="oldVal">Current state of the atom.</param>
        /// <param name="newVal">New state of the atom after successful swap.</param>
        /// <returns>
        /// Returns <see cref="true"/> if set happened, otherwise <see cref="false"/>.
        /// </returns>
        bool CompareAndSet(object oldVal, object newVal);
        /// <summary>
        /// Sets the value of the <see cref="IAtom"/> to a new value. Returns
        /// <see cref="IVector"/> of the old, new, the value of the <see cref="IAtom"/>
        /// before and after the rest.
        /// </summary>
        /// <param name="newVal">New state of the atom after successful reset.</param>
        /// <returns>
        /// Returns <see cref="IVector"/> of the old, new, the value of the <see cref="IAtom"/>
        /// before and after the rest.
        /// </returns>
        IVector Reset(object newVal);
    }
}
