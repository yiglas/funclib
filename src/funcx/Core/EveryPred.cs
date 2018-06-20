using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class EveryPred :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
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
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p2.Invoke(x), this._p3.Invoke(x)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p2.Invoke(x)))
                    : new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x)));
            public object Invoke(object x, object y) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(((IFunction<object, object>)_1).Invoke(x), ((IFunction<object, object>)_1).Invoke(y))), this._ps)
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p2.Invoke(x), this._p3.Invoke(x), this._p1.Invoke(y), this._p2.Invoke(y), this._p3.Invoke(y)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p2.Invoke(x), this._p1.Invoke(y), this._p2.Invoke(y)))
                    : new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p1.Invoke(y)));
            public object Invoke(object x, object y, object z) =>
                this._ps != null
                    ? new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(((IFunction<object, object>)_1).Invoke(x), ((IFunction<object, object>)_1).Invoke(y), ((IFunction<object, object>)_1).Invoke(z))), this._ps)
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p2.Invoke(x), this._p3.Invoke(x), this._p1.Invoke(y), this._p2.Invoke(y), this._p3.Invoke(y), this._p1.Invoke(z), this._p2.Invoke(z), this._p3.Invoke(z)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p2.Invoke(x), this._p1.Invoke(y), this._p2.Invoke(y), this._p1.Invoke(z), this._p2.Invoke(z)))
                    : new Boolean().Invoke(new And().Invoke(this._p1.Invoke(x), this._p1.Invoke(y), this._p1.Invoke(z)));
            public object Invoke(object x, object y, object z, params object[] args) =>
                this._ps != null
                    ? new Boolean().Invoke(new And().Invoke(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => new IsEvery().Invoke(_1, args)), this._ps)))
                    : this._p3 != null ? new Boolean().Invoke(new And().Invoke(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(this._p1.Invoke(_1), this._p2.Invoke(_1), this._p3.Invoke(_1))), args)))
                    : this._p2 != null ? new Boolean().Invoke(new And().Invoke(new Function(this._p1, this._p2, this._p3, this._ps).Invoke(x, y, z), new IsEvery().Invoke(new Function<object, object>(_1 => new And().Invoke(this._p1.Invoke(_1), this._p2.Invoke(_1))), args)))
                    : new Boolean().Invoke(new And().Invoke(new Function(this._p1).Invoke(x, y, z), new IsEvery().Invoke(this._p1, args)));
        }
    }
}
