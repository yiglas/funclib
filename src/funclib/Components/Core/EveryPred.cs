using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
    /// function composes all the predicates that returns a logical true value against all of its arguments, else
    /// it returns false. Note: f is short-circuiting in that it will stop execution on the funclib.Core.First(
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
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the funclib.Core.First(
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns true if p returns a logical true, otherwise false.
        /// </returns>
        public object Invoke(object p) => new Function(p);
        /// <summary>
        /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
        /// function composes all the predicates that returns a logical true value against all of its arguments, else
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the funclib.Core.First(
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns true if p returns a logical true, otherwise false.
        /// </returns>
        public object Invoke(object p1, object p2) => new Function(p1, p2);
        /// <summary>
        /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
        /// function composes all the predicates that returns a logical true value against all of its arguments, else
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the funclib.Core.First(
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p3">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns true if p returns a logical true, otherwise false.
        /// </returns>
        public object Invoke(object p1, object p2, object p3) => new Function(p1, p2, p3);
        /// <summary>
        /// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
        /// function composes all the predicates that returns a logical true value against all of its arguments, else
        /// it returns false. Note: f is short-circuiting in that it will stop execution on the funclib.Core.First(
        /// argument that triggers a logical false result against the original predicates.
        /// </summary>
        /// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="p3">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="ps">Rest of objects that implement <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <returns>
        /// Returns true if p returns a logical true, otherwise false.
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
            object _p1;
            object _p2;
            object _p3;
            object _ps;

            internal Function(object p1) : this(p1, null, null) { }
            internal Function(object p1, object p2) : this(p1, p2, null) { }
            internal Function(object p1, object p2, object p3)
            {
                this._p1 = p1;
                this._p2 = p2;
                this._p3 = p3;
            }
            internal Function(object p1, object p2, object p3, params object[] ps)
            {
                this._ps = funclib.Core.ListS(p1, p2, p3, ps);
            }

            /// <summary>
            /// Returns true.
            /// </summary>
            /// <returns>
            /// Always returns true.
            /// </returns>
            public object Invoke() => true;
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">The object to test the predicates with.</param>
            /// <returns>
            /// Returns true if p returns a logical true, otherwise false.
            /// </returns>
            public object Invoke(object x) =>
                this._ps != null
                    ? funclib.Core.IsEvery(funclib.Core.Func((_1) => Pred(_1, x)), this._ps)
                    : this._p3 != null ? funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x)))
                    : this._p2 != null ? funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p2, x)))
                    : funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x)));
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">First object to test the predicates with.</param>
            /// <param name="y">Second object to test the predicates with.</param>
            /// <returns>
            /// Returns true if p returns a logical true, otherwise false.
            /// </returns>
            public object Invoke(object x, object y) =>
                this._ps != null
                    ? funclib.Core.IsEvery(funclib.Core.Func((object _1) => funclib.Core.And(Pred(_1, x), Pred(_1, y))), this._ps)
                    : this._p3 != null ? funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p3, y)))
                    : this._p2 != null ? funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p1, y), Pred(this._p2, y)))
                    : funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p1, y)));
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">First object to test the predicates with.</param>
            /// <param name="y">Second object to test the predicates with.</param>
            /// <param name="z">Third object to test the predicates with.</param>
            /// <returns>
            /// Returns true if p returns a logical true, otherwise false.
            /// </returns>
            public object Invoke(object x, object y, object z) =>
                this._ps != null
                    ? funclib.Core.IsEvery(funclib.Core.Func((object _1) => funclib.Core.And(Pred(_1, x), Pred(_1, y), Pred(_1, z))), this._ps)
                    : this._p3 != null ? funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p3, y), Pred(this._p1, z), Pred(this._p2, z), Pred(this._p3, z)))
                    : this._p2 != null ? funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p1, z), Pred(this._p2, z)))
                    : funclib.Core.Boolean(funclib.Core.And(Pred(this._p1, x), Pred(this._p1, y), Pred(this._p1, z)));
            /// <summary>
            /// Returns the result of executing the supplied predicates.
            /// </summary>
            /// <param name="x">First object to test the predicates with.</param>
            /// <param name="y">Second object to test the predicates with.</param>
            /// <param name="z">Third object to test the predicates with.</param>
            /// <param name="args">Rest of the objects being tested.</param>
            /// <returns>
            /// Returns true if p returns a logical true, otherwise false.
            /// </returns>
            public object Invoke(object x, object y, object z, params object[] args) =>
                this._ps != null
                    ? funclib.Core.Boolean(funclib.Core.And(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), funclib.Core.IsEvery(funclib.Core.Func((object _1) => funclib.Core.IsEvery(_1, args)), this._ps)))
                    : this._p3 != null ? funclib.Core.Boolean(funclib.Core.And(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), funclib.Core.IsEvery(funclib.Core.Func((object _1) => funclib.Core.And(Pred(this._p1, _1), Pred(this._p2, _1), Pred(this._p3, _1))), args)))
                    : this._p2 != null ? funclib.Core.Boolean(funclib.Core.And(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), funclib.Core.IsEvery(funclib.Core.Func((object _1) => funclib.Core.And(Pred(this._p1, _1), Pred(this._p2, _1))), args)))
                    : funclib.Core.Boolean(funclib.Core.And(new Function(this._p1).Invoke(x, y, z), funclib.Core.IsEvery(this._p1, args)));

            static object Pred(object p, object x) => funclib.Core.Invoke(p, x);
        }
    }
}
