using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Invokes a <see cref="IFunction"/> function with supplied arguments.
    /// </summary>
    public class InvokeFunction :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>
    {
        /// <summary>
        /// Invokes a <see cref="IFunction"/> function with supplied arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Returns the result of calling f with no parameters.
        /// </returns>
        public object Invoke(object f) => Apply.ApplyTo(f, null);
        /// <summary>
        /// Invokes a <see cref="IFunction"/> function with supplied arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">First parameter for the function.</param>
        /// <returns>
        /// Returns the result of calling f with one parameters.
        /// </returns>
        public object Invoke(object f, object x) => Apply.ApplyTo(f, funclib.Core.List(x));
        /// <summary>
        /// Invokes a <see cref="IFunction"/> function with supplied arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">First parameter for the function.</param>
        /// <param name="y">Second parameter for the function.</param>
        /// <returns>
        /// Returns the result of calling f with two parameters.
        /// </returns>
        public object Invoke(object f, object x, object y) => Apply.ApplyTo(f, funclib.Core.List(x, y));
        /// <summary>
        /// Invokes a <see cref="IFunction"/> function with supplied arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="x">First parameter for the function.</param>
        /// <param name="y">Second parameter for the function.</param>
        /// <param name="z">Third parameter for the function.</param>
        /// <returns>
        /// Returns the result of calling f with three parameters.
        /// </returns>
        public object Invoke(object f, object x, object y, object z) => Apply.ApplyTo(f, funclib.Core.List(x, y, z));
        /// <summary>
        /// Invokes a <see cref="IFunction"/> function with supplied arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="a">First parameter for the function.</param>
        /// <param name="b">Second parameter for the function.</param>
        /// <param name="c">Third parameter for the function.</param>
        /// <param name="ds">Rest of the parameter for the function.</param>
        /// <returns>
        /// Returns the result of calling f with all parameters.
        /// </returns>
        public object Invoke(object f, object a, object b, object c, params object[] ds) => Apply.ApplyTo(f, funclib.Core.ListS(a, b, c, ds));
    }
}
