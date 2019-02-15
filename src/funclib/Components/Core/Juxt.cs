using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
    /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
    /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
    /// to the args (left-to-right).
    /// </summary>
    public class Juxt :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </summary>
        /// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </returns>
        public object Invoke(object f) => new Function(f);
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).</summary>
        /// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </returns>
        public object Invoke(object f, object g) => new Function(f, g);
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).</summary>
        /// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="h">Third object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).
        /// </returns>
        public object Invoke(object f, object g, object h) => new Function(f, g, h);
        /// <summary>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
        /// to the args (left-to-right).</summary>
        /// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="h">Third object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="fs">Rest of the object that implements the <see cref="IFunction"/> interface.</param>
        /// <returns>
        /// Takes a set of <see cref="IFunction"/> and returns <see cref="IFunction"/> that is the juxtaposition
        /// of those <see cref="IFunction"/>. The returned <see cref="IFunction"/> takes a variable number or
        /// args, and returns a <see cref="funclib.Components.Core.Vector"/> containing the result of applying each <see cref="IFunction"/>
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
                this._fs = (object[])funclib.Core.ToArray(funclib.Core.ListS(f, g, h, fs));
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
                    : this._h != null ? funclib.Core.Vector(Exec(this._f), Exec(this._g), Exec(this._h))
                    : this._g != null ? funclib.Core.Vector(Exec(this._f), Exec(this._g))
                    : funclib.Core.Vector(Exec(this._f));
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
                    ? funclib.Core.Vector(Exec(this._f, x), Exec(this._g, x), Exec(this._h, x))
                    : this._g != null ? funclib.Core.Vector(Exec(this._f, x), Exec(this._g, x))
                    : funclib.Core.Vector(Exec(this._f, x));
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
                    ? funclib.Core.Vector(Exec(this._f, x, y), Exec(this._g, x, y), Exec(this._h, x, y))
                    : this._g != null ? funclib.Core.Vector(Exec(this._f, x, y), Exec(this._g, x, y))
                    : funclib.Core.Vector(Exec(this._f, x, y));
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
                    ? funclib.Core.Vector(Exec(this._f, x, y, z), Exec(this._g, x, y, z), Exec(this._h, x, y, z))
                    : this._g != null ? funclib.Core.Vector(Exec(this._f, x, y, z), Exec(this._g, x, y, z))
                    : funclib.Core.Vector(Exec(this._f, x, y, z));
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
                    ? funclib.Core.Vector(Exec(this._f, x, y, z, args), Exec(this._g, x, y, z, args), Exec(this._h, x, y, z, args))
                    : this._g != null ? funclib.Core.Vector(Exec(this._f, x, y, z, args), Exec(this._g, x, y, z, args))
                    : funclib.Core.Vector(Exec(this._f, x, y, z, args));

            static object Exec(object f) => funclib.Core.Invoke(f);
            static object Exec(object f, object x) => funclib.Core.Invoke(f, x);
            static object Exec(object f, object x, object y) => funclib.Core.Invoke(f, x, y);
            static object Exec(object f, object x, object y, object z) => funclib.Core.Invoke(f, x, y, z);
            static object Exec(object f, object x, object y, object z, params object[] args) => funclib.Core.Apply(f, x, y, z, args);

            static object Reduce(object fs) => funclib.Core.Reduce1(funclib.Core.Func((_1, _2) => funclib.Core.Conj(_1, Exec(_2))), funclib.Core.Vector(), fs);
            static object Reduce(object fs, object x) => funclib.Core.Reduce1(funclib.Core.Func((_1, _2) => funclib.Core.Conj(_1, Exec(_2, x))), funclib.Core.Vector(), fs);
            static object Reduce(object fs, object x, object y) => funclib.Core.Reduce1(funclib.Core.Func((_1, _2) => funclib.Core.Conj(_1, Exec(_2, x, y))), funclib.Core.Vector(), fs);
            static object Reduce(object fs, object x, object y, object z) => funclib.Core.Reduce1(funclib.Core.Func((_1, _2) => funclib.Core.Conj(_1, Exec(_2, x, y, z))), funclib.Core.Vector(), fs);
            static object Reduce(object fs, object x, object y, object z, params object[] args) => funclib.Core.Reduce1(funclib.Core.Func((_1, _2) => funclib.Core.Conj(_1, Exec(_2, x, y, z, args))), funclib.Core.Vector(), fs);
        }
    }
}
