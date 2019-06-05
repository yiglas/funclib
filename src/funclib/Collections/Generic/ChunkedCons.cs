using System;

namespace funclib.Collections.Generic
{
    public class ChunkedCons<T> :
        ASeq<T>,
        IChunkedSeq<T>
    {
        readonly IChunked<T> _chunk;
        readonly ISeq<T> _more;

        public ChunkedCons(IChunked<T> chunk, ISeq<T> more)
        {
            this._chunk = chunk;
            this._more = more;
        }

        #region Overrides
        public override T First() => this._chunk[0];
        public override ISeq<T> Next()
        {
            if (this._chunk.Count > 1)
            {
                return new ChunkedCons<T>(this._chunk.DropFirst(), this._more);
            }

            return ChunkedNext();
        }
        public override ISeq<T> More()
        {
            if (this._chunk.Count > 1)
            {
                return new ChunkedCons<T>(this._chunk.DropFirst(), this._more);
            }

            return ChunkedMore();
        }
        public override IStack<T> Pop() => throw new NotImplementedException();
        #endregion

        public IChunked<T> ChunkedFirst() => this._chunk;

        public ISeq<T> ChunkedMore()
        {
            if (this._more is null)
            {
                return Generic.List<T>.EMPTY;
            }

            return this._more;
        }

        public ISeq<T> ChunkedNext() => ChunkedMore().Seq();
    }
}