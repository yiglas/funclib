using System;
using System.Text;
using FunctionalLibrary.Core;

namespace FunctionalLibrary.Collections.Internal
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


        public object Reduce(IFunction<object, object, object> f)
        {
            var ret = this._v[this._i];
            for (int x = this._i + 1; x < this._v.Count; x++)
            {
                ret = f.Invoke(ret, this._v[x]);
                if ((bool)new IsReduced().Invoke(ret))
                    return ((IDeref)ret).Deref();
            }

            return ret;
        }
        public object Reduce(IFunction<object, object, object> f, object init)
        {
            var ret = f.Invoke(init, this._v[this._i]);
            for (int x = this._i + 1; x < this._v.Count; x++)
            {
                if ((bool)new IsReduced().Invoke(ret))
                    return ((IDeref)ret).Deref();
                ret = f.Invoke(ret, this._v[x]);
            }
            if ((bool)new IsReduced().Invoke(ret))
                return ((IDeref)ret).Deref();

            return ret;
        }
    }
}
