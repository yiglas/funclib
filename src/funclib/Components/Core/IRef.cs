using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Interface for a <see cref="IRef"/> variable.
    /// </summary>
    public interface IRef :
        IDeref
    {
        /// <summary>
        /// Sets the validator, which will validate the value being set to the <see cref="IRef"/>.
        /// </summary>
        /// <param name="vf">An object that implements the <see cref="IFunction"/> interface.</param>
        void SetValidator(IFunction vf);
        /// <summary>
        /// Returns the current validator function.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="IFunction"/> object of the validator.
        /// </returns>
        IFunction GetValidator();
        /// <summary>
        /// Returns the current watches and their functions.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="IMap"/> with the key/value pair being set to the name of the 
        /// watch and the function to execute.
        /// </returns>
        IMap GetWatches();
        /// <summary>
        /// Adds a watch function to the <see cref="IRef"/> variable.
        /// </summary>
        /// <param name="key">Unique name of the watch.</param>
        /// <param name="callback">An object that implement the <see cref="IFunction"/> that takes 4 args:
        /// a key, the reference, its old-state, its new state.</param>
        /// <returns>
        /// Returns the reference to the <see cref="IRef"/>.
        /// </returns>
        IRef AddWatch(object key, IFunction callback);
        /// <summary>
        /// Removes a watch currently on the <see cref="IRef"/>.
        /// </summary>
        /// <param name="key">Unique name of the watch to remove.</param>
        /// <returns>
        /// Returns the reference to the <see cref="IRef"/>.
        /// </returns>
        IRef RemoveWatch(object key);
    }
}
