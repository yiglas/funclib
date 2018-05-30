using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    sealed class VectorSeq :
        ASeq
    {
        IVector _v;
        int _i;

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
    }
}
