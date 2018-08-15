using funclib.Components.Core;
using System;

namespace funclib.Collections.Internal
{
    sealed class VectorSeq :
        ASeq,
        IReduce
    {
        readonly IVector _v;
        readonly int _i;

        public VectorSeq(IVector v, int i)
        {
            this._v = v;
            this._i = i;
        }

        #region Overrides
        public override int Count => this._v.Count - this._i;
        public override object First() => this._v[this._i];
        public override ISeq Next() => 
            this._i + 1 < this._v.Count 
                ? new VectorSeq(this._v, this._i + 1) 
                : null;
        public override IStack Pop() => throw new NotImplementedException();
        #endregion


        public object Reduce(object f)
        {
            var ret = this._v[this._i];
            for (int x = this._i + 1; x < this._v.Count; x++)
            {
                ret = funclib.Core.Invoke(f, ret, this._v[x]);
                if (ret is Reduced r)
                    return r.Deref();
            }

            return ret;
        }
        public object Reduce(object f, object init)
        {
            var ret = funclib.Core.Invoke(f, init, this._v[this._i]);
            for (int x = this._i + 1; x < this._v.Count; x++)
            {
                if (ret is Reduced r)
                    return r.Deref();
                ret = funclib.Core.Invoke(f, ret, this._v[x]);
            }
            if (ret is Reduced r2)
                return r2.Deref();

            return ret;
        }
    }
}
