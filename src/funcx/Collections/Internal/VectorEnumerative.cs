using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    sealed class VectorEnumerative :
        Enumerative
    {
        IVector _v;
        int _i;

        public VectorEnumerative(IVector v, int i)
        {
            this._v = v;
            this._i = i;
        }

        #region Overrides
        public override int Count => this._v.Count - this._i;
        public override object First() => this._v[this._i];
        public override IEnumerative Next() => 
            this._i + 1 < this._v.Count 
                ? new VectorEnumerative(this._v, this._i + 1) 
                : null;
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}
