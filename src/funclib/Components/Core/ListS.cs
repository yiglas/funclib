using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
    /// last of which will be treated as a sequence.
    /// </summary>
    public class ListS :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>
    {
        /// <summary>
        /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
        /// last of which will be treated as a sequence.
        /// </summary>
        /// <param name="args">An object is passed to the <see cref="Seq"/> function.</param>
        /// <returns>
        /// Returns the result of calling <see cref="Seq"/> with args.
        /// </returns>
        public object Invoke(object args) => funclib.Core.Seq(args);
        /// <summary>
        /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
        /// last of which will be treated as a sequence.
        /// </summary>
        /// <param name="a">First item in the list.</param>
        /// <param name="args">Rest of the items.</param>
        /// <returns>
        /// Returns the result of calling <see cref="Cons"/>.
        /// </returns>
        public object Invoke(object a, object args) => funclib.Core.Cons(a, args);
        /// <summary>
        /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
        /// last of which will be treated as a sequence.
        /// </summary>
        /// <param name="a">First item in the list.</param>
        /// <param name="b">Second item in the list.</param>
        /// <param name="args">Rest of the times.</param>
        /// <returns>
        /// Returns the result of calling <see cref="Cons"/>.
        /// </returns>
        public object Invoke(object a, object b, object args) => funclib.Core.Cons(a, funclib.Core.Cons(b, args));
        /// <summary>
        /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
        /// last of which will be treated as a sequence.
        /// </summary>
        /// <param name="a">First item in the list.</param>
        /// <param name="b">Second item in the list.</param>
        /// <param name="c">Third item in the list.</param>
        /// <param name="args">Rest of the times.</param>
        /// <returns>
        /// Returns the result of calling <see cref="Cons"/>.
        /// </returns>
        public object Invoke(object a, object b, object c, object args) => funclib.Core.Cons(a, funclib.Core.Cons(b, funclib.Core.Cons(c, args)));
        /// <summary>
        /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
        /// last of which will be treated as a sequence.
        /// </summary>
        /// <param name="a">First item in the list.</param>
        /// <param name="b">Second item in the list.</param>
        /// <param name="c">Third item in the list.</param>
        /// <param name="d">Fourth item in the list.</param>
        /// <param name="more">Rest of the times.</param>
        /// <returns>
        /// Returns the result of calling <see cref="Cons"/>.
        /// </returns>
        public object Invoke(object a, object b, object c, object d, params object[] more) => 
            funclib.Core.Cons(a, funclib.Core.Cons(b, funclib.Core.Cons(c, funclib.Core.Cons(d, funclib.Core.Spread(more)))));
    }
}
