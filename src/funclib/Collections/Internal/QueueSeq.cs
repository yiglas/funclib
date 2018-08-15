using System;

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
        public override int Count => (int)funclib.Core.Count(this._f) + (int)funclib.Core.Count(this._rseq);
        public override object First() => this._f.First();
        public override ISeq Next()
        {
            var f1 = this._f.Next();
            var r1 = this._rseq;
            if (f1 is null)
            {
                if (this._rseq is null) return null;
                f1 = this._rseq;
                r1 = null;
            }
            return new QueueSeq(f1, r1);
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}
