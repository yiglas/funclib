using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
    /// function composes all the predicates that returns a logical true value against all of its arguments, else
    /// it returns false. Note: f is short-circuiting in that it will stop execution on the first
    /// argument that triggers a logical false result against the original predicates.
    /// </summary>
    public class EveryPred :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        /// <summary>
        /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
        /// function composes all the predicates that returns a logical true value against all of its arguments, else
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the first
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object p) => new Function(p);
        /// <summary>
        /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
        /// function composes all the predicates that returns a logical true value against all of its arguments, else
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the first
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object p1, object p2) => new Function(p1, p2);
        /// <summary>
        /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
        /// function composes all the predicates that returns a logical true value against all of its arguments, else
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the first
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p3">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object p1, object p2, object p3) => new Function(p1, p2, p3);
        /// <summary>
        /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
        /// function composes all the predicates that returns a logical true value against all of its arguments, else
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the first
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p3">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="ps">Rest of objects that implement <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object p1, object p2, object p3, params object[] ps) => new Function(p1, p2, p3, ps);

        /// <summary>
        /// Internal function that does the <see cref="EveryPred"/>.
        /// </summary>
        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            IFunction<object, object> _p1;
            IFunction<object, object> _p2;
            IFunction<object, object> _p3;
            object _ps;

            internal Function(object p1) : this(p1, null, null) { }
            internal Function(object p1, object p2) : this(p1, p2, null) { }
            internal Function(object p1, object p2, object p3)
            {
                this._p1 = (IFunction<object, object>)p1;
                this._p2 = (IFunction<object, object>)p2;
                this._p3 = (IFunction<object, object>)p3;
            }
            internal Function(object p1, object p2, object p3, params object[] ps)
            {
                this._ps = new ListS().Invoke(p1, p2, p3, ps);
            }

            /// <summary>
            /// Returns <see cref="true"/>.
            /// </summary>
            /// <returns>
            /// Always returns <see cref="true"/>.
            /// </returns>
            public object Invoke() => true;
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">The object to test the predicates with.</param>
            /// <returns>
            /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
            /// </returns>
            public object Invoke(object x) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => ((IFunction<object, object>)_1).Invoke(x)), this._ps)
                    : this._p3 != null ? boolean(and(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x)))
                    : this._p2 != null ? boolean(and(Pred(this._p1, x), Pred(this._p2, x)))
                    : boolean(and(Pred(this._p1, x)));
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">First object to test the predicates with.</param>
            /// <param name="y">Second object to test the predicates with.</param>
            /// <returns>
            /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
            /// </returns>
            public object Invoke(object x, object y) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => and(Pred(_1, x), Pred(_1, y))), this._ps)
                    : this._p3 != null ? boolean(and(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p3, y)))
                    : this._p2 != null ? boolean(and(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p1, y), Pred(this._p2, y)))
                    : boolean(and(Pred(this._p1, x), Pred(this._p1, y)));
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">First object to test the predicates with.</param>
            /// <param name="y">Second object to test the predicates with.</param>
            /// <param name="z">Third object to test the predicates with.</param>
            /// <returns>
            /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
            /// </returns>
            public object Invoke(object x, object y, object z) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => and(Pred(_1, x), Pred(_1, y), Pred(_1, z))), this._ps)
                    : this._p3 != null ? boolean(and(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p3, y), Pred(this._p1, z), Pred(this._p2, z), Pred(this._p3, z)))
                    : this._p2 != null ? boolean(and(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p1, z), Pred(this._p2, z)))
                    : boolean(and(Pred(this._p1, x), Pred(this._p1, y), Pred(this._p1, z)));
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">First object to test the predicates with.</param>
            /// <param name="y">Second object to test the predicates with.</param>
            /// <param name="z">Third object to test the predicates with.</param>
            /// <param name="args">Rest of the objects being tested.</param>
            /// <returns>
            /// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
            /// </returns>
            public object Invoke(object x, object y, object z, params object[] args) =>
                this._ps != null
                    ? boolean(and(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => new IsEvery().Invoke(_1, args)), this._ps)))
                    : this._p3 != null ? boolean(and(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => and(this._p1.Invoke(_1), this._p2.Invoke(_1), this._p3.Invoke(_1))), args)))
                    : this._p2 != null ? boolean(and(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => and(this._p1.Invoke(_1), this._p2.Invoke(_1))), args)))
                    : boolean(and(new Function(this._p1).Invoke(x, y, z), new IsEvery().Invoke(this._p1, args)));

            IFunction<object> Pred(IFunction<object, object> p, object x) => new Function<object>(() => p.Invoke(x));
            IFunction<object> Pred(object p, object x) => new Function<object>(() => ((IFunction<object, object>)p).Invoke(x));
        }
    }
}
