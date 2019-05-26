using funclib.Components.Core;
using System;

namespace funclib.Collections.Generic.Internal
{
    sealed class VectorSeq<T> :
        ASeq<T>,
        IReduce<T>
    {
        readonly IVector<T> _v;
        readonly int _i;

        public VectorSeq(IVector<T> v, int i)
        {
            this._v = v;
            this._i = i;
        }

        #region Overrides
        public override int Count => this._v.Count - this._i;
        public override T First() => this._v[this._i];
        public override ISeq<T> Next() =>
            this._i + 1 < this._v.Count
                ? new VectorSeq<T>(this._v, this._i + 1)
                : null;
        public override IStack<T> Pop() => throw new NotImplementedException();
        #endregion


        public T Reduce(Func<T, T, T> f)
        {
            var ret = this._v[this._i];
            for (int x = this._i + 1; x < this._v.Count; x++)
            {
                ret = f(ret, this._v[x]);
            }

            return ret;
        }
        public TAccumulate Reduce<TAccumulate>(Func<TAccumulate, T, TAccumulate> f, TAccumulate init)
        {
            var ret = f(init, this._v[this._i]);
            for (int x = this._i + 1; x < this._v.Count; x++)
            {
                ret = f(ret, this._v[x]);
            }

            return ret;
        }
    }
}
