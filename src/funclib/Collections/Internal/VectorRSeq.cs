using System;
using System.Text;
using funclib.Components.Core;
using static funclib.core;

namespace funclib.Collections.Internal
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

        public object Reduce(object f)
        {
            object ret = this._v[this._i];
            for (int x = this._i - 1; x >= 0; x--)
            {
                ret = invoke(f, ret, this._v[x]);
                if (ret is Reduced r)
                    return r.Deref();
            }

            return ret;
        }
        public object Reduce(object f, object init)
        {
            var ret = invoke(f, init, this._v[this._i]);
            for (int x = this._i - 1; x >= 0; x--)
            {
                if (ret is Reduced r)
                    return r.Deref();
                ret = invoke(f, ret, this._v[x]);
            }
            if (ret is Reduced r2)
                return r2.Deref();

            return ret;
        }
    }
}
