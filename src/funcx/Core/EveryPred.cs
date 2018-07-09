﻿using System;
using System.Text;

namespace FunctionalLibrary.Core
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
        /// Returns true if p returns a logical true, otherwise false.
        /// </returns>
        public object Invoke(object p) => new Function(p);
        public object Invoke(object p1, object p2) => new Function(p1, p2);
        public object Invoke(object p1, object p2, object p3) => new Function(p1, p2, p3);
        public object Invoke(object p1, object p2, object p3, params object[] ps) => new Function(p1, p2, p3, ps);

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

            public Function(object p1) : this(p1, null, null) { }
            public Function(object p1, object p2) : this(p1, p2, null) { }
            public Function(object p1, object p2, object p3)
            {
                this._p1 = (IFunction<object, object>)p1;
                this._p2 = (IFunction<object, object>)p2;
                this._p3 = (IFunction<object, object>)p3;
            }
            public Function(object p1, object p2, object p3, params object[] ps)
            {
                this._ps = new ListS().Invoke(p1, p2, p3, ps);
            }

            public object Invoke() => true;
            public object Invoke(object x) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => ((IFunction<object, object>)_1).Invoke(x)), this._ps)
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p2, x)))
                    : new Boolean().Invoke(new And().Invoke(Pred(this._p1, x)));
            public object Invoke(object x, object y) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(Pred(_1, x), Pred(_1, y))), this._ps)
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p3, y)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p1, y), Pred(this._p2, y)))
                    : new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p1, y)));
            public object Invoke(object x, object y, object z) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(Pred(_1, x), Pred(_1, y), Pred(_1, z))), this._ps)
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p3, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p3, y), Pred(this._p1, z), Pred(this._p2, z), Pred(this._p3, z)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p2, x), Pred(this._p1, y), Pred(this._p2, y), Pred(this._p1, z), Pred(this._p2, z)))
                    : new Boolean().Invoke(new And().Invoke(Pred(this._p1, x), Pred(this._p1, y), Pred(this._p1, z)));
            public object Invoke(object x, object y, object z, params object[] args) =>
                this._ps != null
                    ? new Boolean().Invoke(new And().Invoke(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => new IsEvery().Invoke(_1, args)), this._ps)))
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(this._p1.Invoke(_1), this._p2.Invoke(_1), this._p3.Invoke(_1))), args)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(this._p1.Invoke(_1), this._p2.Invoke(_1))), args)))
                    : new Boolean().Invoke(new And().Invoke(new Function(this._p1).Invoke(x, y, z), new IsEvery().Invoke(this._p1, args)));

            IFunction<object> Pred(IFunction<object, object> p, object x) => new Function<object>(() => p.Invoke(x));
            IFunction<object> Pred(object p, object x) => new Function<object>(() => ((IFunction<object, object>)p).Invoke(x));
        }
    }
}
