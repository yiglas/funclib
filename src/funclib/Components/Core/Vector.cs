using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Creates a new <see cref="Collections.Vector"/> containing the args.
    /// </summary>
    public class Vector :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunction<object, object, object, object, object, object>,
        IFunction<object, object, object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object, object, object>
    {
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <returns>
        /// Returns the <see cref="Collections.Vector.EMPTY"/> object.
        /// </returns>
        public object Invoke() => Collections.Vector.EMPTY;
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> containing the args.
        /// </returns>
        public object Invoke(object a) => Collections.Vector.Create(a);
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> containing the args.
        /// </returns>
        public object Invoke(object a, object b) => Collections.Vector.Create(a, b);
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> containing the args.
        /// </returns>
        public object Invoke(object a, object b, object c) => Collections.Vector.Create(a, b, c);
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> containing the args.
        /// </returns>
        public object Invoke(object a, object b, object c, object d) => Collections.Vector.Create(a, b, c, d);
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="e">Fifth value of the <see cref="Collections.Vector"/>.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> containing the args.
        /// </returns>
        public object Invoke(object a, object b, object c, object d, object e) => Collections.Vector.Create(a, b, c, d, e);
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="e">Fifth value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="f">Sixth value of the <see cref="Collections.Vector"/>.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> containing the args.
        /// </returns>
        public object Invoke(object a, object b, object c, object d, object e, object f) => Collections.Vector.Create(a, b, c, d, e, f);
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the args.
        /// </summary>
        /// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="e">Fifth value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="f">Sixth value of the <see cref="Collections.Vector"/>.</param>
        /// <param name="args">Rest of the values added to the <see cref="Collections.Vector"/>.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> containing the args.
        /// </returns>
        public object Invoke(object a, object b, object c, object d, object e, object f, params object[] args) =>
            Collections.Vector.Create((ISeq)funclib.Core.Cons(a, funclib.Core.Cons(b, funclib.Core.Cons(c, funclib.Core.Cons(d, funclib.Core.Cons(e, funclib.Core.Cons(f, args)))))));
    }
}
