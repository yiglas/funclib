using funclib.Components.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Collections.Internal
{
    class QueueSeq :
        ASeq
    {
        readonly ISeq _f;
        readonly ISeq _rseq;

        internal QueueSeq(ISeq f, ISeq rseq)
        {
            this._f = f;
            this._rseq = rseq;
        }

        #region Overrides
        public override int Count => (int)new Count().Invoke(this._f) + (int)new Count().Invoke(this._rseq);
        public override object First() => this._f.First();
        public override ISeq Next()
        {
            var f1 = this._f.Next();
            var r1 = this._rseq;
            if (f1 == null)
            {
                if (this._rseq == null) return null;
                f1 = this._rseq;
                r1 = null;
            }
            return new QueueSeq(f1, r1);
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}
