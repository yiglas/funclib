using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Sets the validator function for <see cref="IRef"/> variables. Validator 
    /// function must be null or a side-effect-free <see cref="IFunction"/> of
    /// one argument, which will be passed the intended new state of any state
    /// change. If the new state is unacceptable, the function should either
    /// return false or throw an exception.
    /// </summary>
    public class SetValidatorǃ :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Sets the validator function for <see cref="IRef"/> variables. Validator 
        /// function must be null or a side-effect-free <see cref="IFunction"/> of
        /// one argument, which will be passed the intended new state of any state
        /// change. If the new state is unacceptable, the function should either
        /// return false or throw an exception.
        /// </summary>
        /// <param name="ref">An object that implements the <see cref="IRef"/> interface.</param>
        /// <param name="validatorFn">An object that implements the <see cref="IFunction"/> interface, that takes one parameter.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(object @ref, object validatorFn)
        {
            ((IRef)@ref).SetValidator((IFunction)validatorFn);
            return null;
        }
    }
}
