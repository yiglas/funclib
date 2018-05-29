using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    sealed class ChunkedEnumerative :
        Enumerative,
        IChunkedEnumerative
    {
        readonly Vector _vec;
        readonly object[] _node;
        readonly int _i;
        readonly int _offset;

        public ChunkedEnumerative(Vector vec, int i, int offset) :
            this(vec, vec.ToArray(i), i, offset) { }

        public ChunkedEnumerative(Vector vec, object[] node, int i, int offset)
        {
            this._vec = vec;
            this._node = node;
            this._i = i;
            this._offset = offset;
        }

        #region Overrides
        public override int Count => this._vec.Count - (this._i + this._offset);
        public override object First() => this._node[this._offset];
        public override IEnumerative Next() =>
            this._offset + 1 < this._node.Length
                ? new ChunkedEnumerative(this._vec, this._node, this._i, this._offset + 1)
                : ChunkedNext();
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public IEnumerative ChunkcedMore()
        {
            var e = ChunkedNext();
            if (e == null)
                return List.EMPTY;
            return e;
        }
        public IChunked ChunkedFirst() => new ArrayChunked(this._node, this._offset);
        public IEnumerative ChunkedNext() =>
            (this._i + this._node.Length < this._vec.Count)
                ? new ChunkedEnumerative(this._vec, this._i + this._node.Length, 0)
                : null;
    }
}
