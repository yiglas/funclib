using funclib.Collections;
using System;
using System.Text;

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
        public object Invoke(object args) => new Seq().Invoke(args);
        /// <summary>
        /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
        /// last of which will be treated as a sequence.
        /// </summary>
        /// <param name="a">First item in the list.</param>
        /// <param name="args">Rest of the items.</param>
        /// <returns>
        /// Returns the result of calling <see cref="Cons"/>.
        /// </returns>
        public object Invoke(object a, object args) => new Cons().Invoke(a, args);
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
        public object Invoke(object a, object b, object args) => new Cons().Invoke(a, new Cons().Invoke(b, args));
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
        public object Invoke(object a, object b, object c, object args) => new Cons().Invoke(a, new Cons().Invoke(b, new Cons().Invoke(c, args)));
        /// <summary>
        /// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
        /// last of which will be treated as a sequence.
        /// </summary>
        /// <param name="a">First item in the list.</param>
        /// <param name="b">Second item in the list.</param>
        /// <param name="c">Third item in the list.</param>
        /// <param name="d">Fourth item in the list.</param>
        /// <param name="args">Rest of the times.</param>
        /// <returns>
        /// Returns the result of calling <see cref="Cons"/>.
        /// </returns>
        public object Invoke(object a, object b, object c, object d, params object[] more) => 
            new Cons().Invoke(a, new Cons().Invoke(b, new Cons().Invoke(c, new Cons().Invoke(d, new Spread().Invoke(more)))));
    }
}
