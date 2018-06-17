using System;
using System.Text;
using FunctionalLibrary.Core;

namespace FunctionalLibrary.Collections.Internal
{
    public class VectorRSeq :
        ASeq,
        IReduce
    {
        readonly IVector _v;
        readonly int _i;

        public VectorRSeq(IVector v, int i)
        {
            this._v = v;
            this._i = i;
        }

        #region Overrides
        public override int Count => this._i + 1;
        public override object First() => this._v[this._i];
        public override ISeq Next() => this._i > 0 ? new VectorRSeq(this._v, this._i - 1) : null;
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public object Reduce(IFunction f)
        {
            object ret = this._v[this._i];
            for (int x = this._i - 1; x >= 0; x--)
            {
                ret = ((IFunction<object, object, object>)f).Invoke(ret, this._v[x]);
                if (ret is Reduced r)
                    return r.Deref();
            }

            return ret;
        }
        public object Reduce(IFunction f, object init)
        {
            var ret = ((IFunction<object, object, object>)f).Invoke(init, this._v[this._i]);
            for (int x = this._i - 1; x >= 0; x--)
            {
                if (ret is Reduced r)
                    return r.Deref();
                ret = ((IFunction<object, object, object>)f).Invoke(ret, this._v[x]);
            }
            if (ret is Reduced r2)
                return r2.Deref();

            return ret;
        }
    }
}
