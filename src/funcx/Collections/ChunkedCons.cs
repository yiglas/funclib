using System;
using System.Text;
using FunctionalLibrary.Core;

namespace FunctionalLibrary.Collections
{
    public class ChunkedCons :
        ASeq,
        IChunkedSeq
    {
        readonly IChunked _chunk;
        readonly ISeq _more;

        public ChunkedCons(IChunked chunk, ISeq more)
        {
            this._chunk = chunk;
            this._more = more;
        }

        #region Overrides
        public override object First() => this._chunk[0];
        public override ISeq Next() => this._chunk.Count > 1 ? new ChunkedCons(this._chunk.DropFirst(), this._more) : ChunkedNext();
        public override ISeq More() =>
            this._chunk.Count > 1
                ? new ChunkedCons(this._chunk.DropFirst(), this._more)
                : this._more == null ? List.EMPTY
                : this._more;
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public ISeq ChunkedMore() => this._more == null ? List.EMPTY : this._more;
        public IChunked ChunkedFirst() => this._chunk;
        public ISeq ChunkedNext() => ChunkedMore().Seq();
    }
}
