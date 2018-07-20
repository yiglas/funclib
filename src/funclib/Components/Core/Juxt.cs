using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
    /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
    /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
    /// to the args (left-to-right).
    /// </summary>
    public class Juxt :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </returns>
        public object Invoke(object f) => new Function(f);
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).</summary>
        /// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </returns>
        public object Invoke(object f, object g) => new Function(f, g);
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).</summary>
        /// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="h">Third object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </returns>
        public object Invoke(object f, object g, object h) => new Function(f, g, h);
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).</summary>
        /// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="h">Third object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="fs">Rest of the object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or 
        /// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </returns>
        public object Invoke(object f, object g, object h, params object[] fs) => new Function(f, g, h, fs);

        /// <summary>
        /// Internal function that does the <see cref="Juxt"/>.
        /// </summary>
        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            object _f;
            object _g;
            object _h;
            object[] _fs;
            
            internal Function(object f) : this(f, null, null) { }
            internal Function(object f, object g) : this(f, g, null) { }
            internal Function(object f, object g, object h)
            {
                this._f = f;
                this._g = g;
                this._h = h;
            }
            internal Function(object f, object g, object h, object[] fs) :
                this(null, null, null)
            {
                this._fs = (object[])new ToArray().Invoke(new ListS().Invoke(f, g, h, fs));
            }

            /// <summary>
            /// Invoke the functions without any parameters.
            /// </summary>
            /// <returns>
            /// Returns a <see cref="Collections.Vector"/> with the results of executing the functions.
            /// </returns>
            public object Invoke() =>
                this._fs != null
                    ? Reduce(this._fs)
                    : this._h != null ? new Vector().Invoke(Exec(this._f), Exec(this._g), Exec(this._h))
                    : this._g != null ? new Vector().Invoke(Exec(this._f), Exec(this._g))
                    : new Vector().Invoke(Exec(this._f));
            /// <summary>
            /// Invoke the functions with a single parameter
            /// </summary>
            /// <param name="x">First parameter passed to each function.</param>
            /// <returns>
            /// Returns a <see cref="Collections.Vector"/> with the results of executing the functions.
            /// </returns>
            public object Invoke(object x) =>
                this._fs != null
                    ? Reduce(this._fs, x)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x), Exec(this._g, x), Exec(this._h, x))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x), Exec(this._g, x))
                    : new Vector().Invoke(Exec(this._f, x));
            /// <summary>
            /// Invoke the functions with a multiple parameter
            /// </summary>
            /// <param name="x">First parameter passed to each function.</param>
            /// <param name="y">Second parameter passed to each function.</param>
            /// <returns>
            /// Returns a <see cref="Collections.Vector"/> with the results of executing the functions.
            /// </returns>
            public object Invoke(object x, object y) =>
                this._fs != null
                    ? Reduce(this._fs, x, y)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x, y), Exec(this._g, x, y), Exec(this._h, x, y))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x, y), Exec(this._g, x, y))
                    : new Vector().Invoke(Exec(this._f, x, y));
            /// <summary>
            /// Invoke the functions with a multiple parameter
            /// </summary>
            /// <param name="x">First parameter passed to each function.</param>
            /// <param name="y">Second parameter passed to each function.</param>
            /// <param name="z">Third parameter passed to each function.</param>
            /// <returns>
            /// Returns a <see cref="Collections.Vector"/> with the results of executing the functions.
            /// </returns>
            public object Invoke(object x, object y, object z) =>
                this._fs != null
                    ? Reduce(this._fs, x, y, z)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x, y, z), Exec(this._g, x, y, z), Exec(this._h, x, y, z))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x, y, z), Exec(this._g, x, y, z))
                    : new Vector().Invoke(Exec(this._f, x, y, z));
            /// <summary>
            /// Invoke the functions with a multiple parameter
            /// </summary>
            /// <param name="x">First parameter passed to each function.</param>
            /// <param name="y">Second parameter passed to each function.</param>
            /// <param name="z">Third parameter passed to each function.</param>
            /// <param name="args">Rest of the parameters passed to each function.</param>
            /// <returns>
            /// Returns a <see cref="Collections.Vector"/> with the results of executing the functions.
            /// </returns>
            public object Invoke(object x, object y, object z, params object[] args) =>
                this._fs != null
                    ? Reduce(this._fs, x, y, z, args)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x, y, z, args), Exec(this._g, x, y, z, args), Exec(this._h, x, y, z, args))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x, y, z, args), Exec(this._g, x, y, z, args))
                    : new Vector().Invoke(Exec(this._f, x, y, z, args));

            object Exec(object f) => ((IFunction<object>)f).Invoke();
            object Exec(object f, object x) => ((IFunction<object, object>)f).Invoke(x);
            object Exec(object f, object x, object y) => ((IFunction<object, object, object>)f).Invoke(x, y);
            object Exec(object f, object x, object y, object z) => ((IFunction<object, object, object, object>)f).Invoke(x, y, z);
            object Exec(object f, object x, object y, object z, params object[] args) => apply(f, x, y, z, args);

            object Reduce(object fs) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2))), new Vector().Invoke(), fs);
            object Reduce(object fs, object x) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x))), new Vector().Invoke(), fs);
            object Reduce(object fs, object x, object y) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x, y))), new Vector().Invoke(), fs);
            object Reduce(object fs, object x, object y, object z) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x, y, z))), new Vector().Invoke(), fs);
            object Reduce(object fs, object x, object y, object z, params object[] args) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x, y, z, args))), new Vector().Invoke(), fs);
        }
    }
}
