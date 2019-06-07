using System;

namespace funclib.Collections.Generic.Internal
{
    sealed class ChunkedSeq<T> :
        ASeq<T>,
        IChunkedSeq<T>
    {
        readonly Vector<T> _vec;
        readonly UnionType<T, VectorNode<T>>[] _node;
        readonly int _i;
        readonly int _offset;

        public ChunkedSeq(Vector<T> vec, int i, int offset) :
            this(vec, vec.ToArray(i), i, offset)
        { }

        public ChunkedSeq(Vector<T> vec, UnionType<T, VectorNode<T>>[] node, int i, int offset)
        {
            this._vec = vec;
            this._node = node;
            this._i = i;
            this._offset = offset;
        }

        #region Overrides
        public override int Count => this._vec.Count - (this._i + this._offset);
        public override T First() => this._node[this._offset];
        public override ISeq<T> Next()
        {
            if (this._offset + 1 < this._node.Length)
            {
                return new ChunkedSeq<T>(this._vec, this._node, this._i, this._offset + 1);
            }

            return ChunkedNext();
        }
        public override IStack<T> Pop() => throw new NotImplementedException();
        #endregion

        public ISeq<T> ChunkedMore()
        {
            var e = ChunkedNext();
            if (e is null)
            {
                return List<T>.EMPTY;
            }
            return e;
        }
        public IChunked<T> ChunkedFirst() => new ArrayChunked<T>(this._node, this._offset);
        public ISeq<T> ChunkedNext()
        {
            if (this._i + this._node.Length < this._vec.Count)
            {
                return new ChunkedSeq<T>(this._vec, this._i + this._node.Length, 0);
            }

            return null;
        }
    }
}